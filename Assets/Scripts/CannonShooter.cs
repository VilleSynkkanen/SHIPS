using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : ChargedShooter
{
    public override void Shoot()
    {
        foreach (Transform location in ShotLocations)
        {
            float forceMultiplier = Random.Range(chargedData.MinForce, chargedData.MaxForce);
            float rotation = Random.Range(-chargedData.RotationVariation, chargedData.RotationVariation);

            GameObject clone = Instantiate(Projectile, location.position, location.rotation);
            clone.tag = tag;
            Rigidbody2D ball = clone.GetComponent<Rigidbody2D>();
            ball.rotation += rotation;
            ball.AddRelativeForce(Vector2.up * chargedData.ShotForce * shotCharge * forceMultiplier);
            rb.AddRelativeForce(Recoil * chargedData.ShotForce * shotCharge * forceMultiplier);
            location.gameObject.GetComponent<AudioSource>().Play();

            if(Data.LimitedAmmo)
            {
                ExpendAmmo();
            }
        }

        TriggerShotEvent();
    }
}
