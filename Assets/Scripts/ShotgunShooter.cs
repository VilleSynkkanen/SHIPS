public class ShotgunShooter : CannonShooter
{
    ShotgunShooterData shotgunData;
    
    private new void Start()
    {
        base.Start();
        shotgunData = (ShotgunShooterData)Data;
    }

    public override void Shoot()
    {
        for(int i = 0; i < shotgunData.ShotAmount; i++)
        {
            StartCoroutine(Shot(1, 0, false));
        }
        TriggerShotEvent();
    }
}
