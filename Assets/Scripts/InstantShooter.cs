public abstract class InstantShooter : Shooter
{
    public override void ShotInput(bool input)
    {
        if (Data.LimitedAmmo && ammoLeft <= 0)
        {
            return;
        }

        if (input && cooldownLeft <= 0)
        {
            Shoot();
            SetCooldown(cooldownLeft + Data.ShotCooldown);
        }
    }
}
