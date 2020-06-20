using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantShooter : Shooter
{
    
    public override void ShotInput(bool input)
    {
        if (Data.limitedAmmo && ammoLeft <= 0)      // move to shooter?
        {
            return;
        }

        if (input && cooldownLeft <= 0)
        {
            Shoot();
            SetCooldown(cooldownLeft + Data.shotCooldown);      // move to shooter??
        }
    }
}
