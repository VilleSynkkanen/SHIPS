public class BurstCannonShooter : CannonShooter
{
    BurstShooterData burstData;
    
    private new void Start()
    {
        base.Start();
        burstData = (BurstShooterData)Data;
    }

    public override void Shoot()
    {
        StartCoroutine(Shot(burstData.ProjectileAmount, burstData.BurstCooldown));
    }
}
