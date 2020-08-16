using UnityEngine;
using UnityEngine.Events;

public class FlamethrowerShooter : InstantShooter
{
    [SerializeField] FlamethrowerCollider col;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float soundFadeStart;
    [SerializeField] float soundFadeAmount;
    [SerializeField] UnityEvent OnDrainedAmmo;

    FlamethrowerShooterData flamerData;
    float timeShot;
    bool playingAudio;
    float originalVolume;

    public float heat { get; private set; }
    public bool overheated { get; private set; }
    
    private void Start()
    {
        flamerData = (FlamethrowerShooterData)Data;
        heat = 0;
        timeShot = Time.time;
        playingAudio = false;
        originalVolume = audioSource.volume;
    }

    public new void Update()
    {
        base.Update();
        if (heat >= 1)
            overheated = true;

        float timeDiff = Time.time - timeShot;

        if (timeDiff > flamerData.HeatDissipationDelay)
        {
            heat -= flamerData.HeatDissipation * Time.deltaTime;
            if (heat <= 0)
            {
                heat = 0;
                overheated = false;
            }   
        }

        if (timeDiff >= soundFadeStart && timeDiff <= 1 / soundFadeAmount)
        {
            audioSource.volume -= soundFadeAmount * Time.deltaTime;
            if(audioSource.volume <= 0)
            {
                audioSource.Stop();
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

            
            if (!playingAudio)
            {
                audioSource.volume = originalVolume;
                audioSource.Play();
            }
            
            TriggerShotEvent();
        }
    }
}
