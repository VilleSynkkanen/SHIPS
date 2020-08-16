using UnityEngine;

public abstract class ChargedShooter : Shooter
{
    public ChargedShooterData chargedData { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public float shotCharge { get; private set; }

    public void Start()
    {
        chargedData = (ChargedShooterData)Data;
        rb = GetComponent<Rigidbody2D>();
    }

    public override void ShotInput(bool input)
    {
        if (Data.LimitedAmmo && ammoLeft <= 0)
        {
            return;
        }

        if (input && cooldownLeft <= 0)
        {
            shotCharge += chargedData.ChargeSpeed * Time.deltaTime;
            if (shotCharge >= 1)
            {
                Shoot();
                shotCharge = 0;
                SetCooldown(cooldownLeft + chargedData.ShotCooldown);
            }
        }
        else if (!input && cooldownLeft <= 0 && shotCharge > chargedData.MinimumCharge)
        {
            Shoot();
            shotCharge = 0;
            SetCooldown(cooldownLeft + chargedData.ShotCooldown);
        }
        else
        {
            shotCharge = 0;
        }
    }
}
