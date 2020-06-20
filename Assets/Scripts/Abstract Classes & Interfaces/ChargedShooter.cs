using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChargedShooter : Shooter
{
    public ChargedShooterData chargedData { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public float shotCharge { get; private set; }
    
    private void Start()
    {
        chargedData = (ChargedShooterData)Data;
        rb = GetComponent<Rigidbody2D>();
    }

    public override void ShotInput(bool input)
    {
        if (Data.limitedAmmo && ammoLeft <= 0)
        {
            return;
        }

        if (input && cooldownLeft <= 0)
        {
            shotCharge += chargedData.chargeSpeed * Time.deltaTime;
            if (shotCharge >= 1)
            {
                Shoot();
                shotCharge = 0;
                SetCooldown(chargedData.shotCooldown);
            }
        }
        else if (!input && cooldownLeft <= 0 && shotCharge > chargedData.minimumCharge)
        {
            Shoot();
            shotCharge = 0;
            SetCooldown(chargedData.shotCooldown);
        }
        else
        {
            shotCharge = 0;
        }
    }
}
