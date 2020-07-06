using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoShooter : ChargedShooter
{
    TorpedoShooterData torpData;
    Rigidbody2D rb;

    public new void Start()
    {
        base.Start();
        torpData = (TorpedoShooterData)Data;
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Shoot()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(torpData.LaunchDelay);

        foreach (Transform location in ShotLocations)
        {
            GameObject clone = Instantiate(Projectile, location.position, location.rotation);
            clone.transform.SetProjectileParent();
            clone.tag = tag;
            Rigidbody2D projectile = clone.GetComponent<Rigidbody2D>();
            projectile.velocity = rb.velocity;
            StartCoroutine(ActivateCollider(clone.GetComponent<Collider2D>()));
            location.gameObject.GetComponent<AudioSource>().Play();

            if (Data.LimitedAmmo)
            {
                ExpendAmmo();
            }
        }

        TriggerShotEvent();
    }

    IEnumerator ActivateCollider(Collider2D collider)
    {
        yield return new WaitForSeconds(torpData.ActivationDelay);
        collider.enabled = true;
    }
}
