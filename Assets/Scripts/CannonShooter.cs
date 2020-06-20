using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : ChargedShooter
{
    public override void Shoot()
    {
        foreach (Transform location in ShotLocations)
        {
            float forceMultiplier = Random.Range(chargedData.minForce, chargedData.maxForce);
            float rotation = Random.Range(-chargedData.rotationVariation, chargedData.rotationVariation);

            GameObject clone = Instantiate(Projectile, location.position, location.rotation);
            clone.tag = tag;
            Rigidbody2D ball = clone.GetComponent<Rigidbody2D>();
            ball.rotation += rotation;
            ball.AddRelativeForce(Vector2.up * chargedData.shotForce * shotCharge * forceMultiplier);
            rb.AddRelativeForce(Recoil * chargedData.shotForce * shotCharge * forceMultiplier);
            location.gameObject.GetComponent<AudioSource>().Play();

            if(Data.limitedAmmo)
            {
                ExpendAmmo();
            }
        }

        TriggerShotEvent();
    }
}
