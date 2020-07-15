using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlamethrowerShooter : InstantShooter
{
    [SerializeField] FlamethrowerCollider col;
    FlamethrowerShooterData flamerData;
    public float heat { get; private set; }
    float timeShot;
    public bool overheated { get; private set; }

    [SerializeField] UnityEvent OnDrainedAmmo;

    private void Start()
    {
        flamerData = (FlamethrowerShooterData)Data;
        heat = 0;
        timeShot = Time.time;
    }

    public new void Update()
    {
        base.Update();
        if (heat >= 1)
            overheated = true;
        
        if(Time.time - timeShot > flamerData.HeatDissipationDelay)
        {
            heat -= flamerData.HeatDissipation * Time.deltaTime;
            if (heat <= 0)
            {
                heat = 0;
                overheated = false;
            }   
        }
    }
    
    public override void Shoot()
    {
        if(heat < 1 && !overheated)
        {
            foreach (ShipSegment segment in col.Segments)
            {
                segment.TakeDamage(flamerData.DamagePerTick);
            }

            heat += flamerData.HeatPerTick;
            timeShot = Time.time;

            if (Data.LimitedAmmo)
            {
                ExpendAmmo();
                if (ammoLeft == 0)
                    OnDrainedAmmo.Invoke();
            }

            TriggerShotEvent();
        }
    }
}
