using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : ChargedShooter
{
    public override void Shoot()
    {
        StartCoroutine(Shot());
    }

    public IEnumerator Shot(int burst=1, float burstTime=0)
    {
        float charge = shotCharge;
        for(int i = 0; i < burst; i++)
        {
            foreach (Transform location in ShotLocations)
            {
                float forceMultiplier = Random.Range(chargedData.MinForce, chargedData.MaxForce);
                float rotation = Random.Range(-chargedData.RotationVariation, chargedData.RotationVariation);

                GameObject clone = Instantiate(Projectile, location.position, location.rotation);
                clone.transform.SetProjectileParent();
                clone.tag = tag;
                Rigidbody2D ball = clone.GetComponent<Rigidbody2D>();
                ball.rotation += rotation;
                ball.AddRelativeForce(Vector2.up * chargedData.ShotForce * charge * forceMultiplier);
                rb.AddRelativeForce(Recoil * chargedData.ShotForce * shotCharge * forceMultiplier);
                location.gameObject.GetComponent<AudioSource>().Play();

                if (Data.LimitedAmmo)
                {
                    ExpendAmmo();
                }
            }

            TriggerShotEvent();
            yield return new WaitForSeconds(burstTime);
        }
    }
}
