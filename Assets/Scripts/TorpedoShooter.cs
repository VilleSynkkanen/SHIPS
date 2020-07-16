using System.Collections;
using UnityEngine;

public class TorpedoShooter : ChargedShooter
{
    TorpedoShooterData torpData;

    public new void Start()
    {
        base.Start();
        torpData = (TorpedoShooterData)Data;
    }

    public override void Shoot()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        foreach (Transform location in ShotLocations)
        {
            location.gameObject.GetComponent<AudioSource>().Play();
        }

        yield return new WaitForSeconds(torpData.LaunchDelay);

        foreach (Transform location in ShotLocations)
        {
            GameObject clone = Instantiate(Projectile, location.position, location.rotation);
            clone.transform.SetProjectileParent();
            clone.tag = tag;
            Rigidbody2D projectile = clone.GetComponent<Rigidbody2D>();
            projectile.velocity = rb.velocity;
            StartCoroutine(ActivateCollider(clone.GetComponent<Collider2D>()));
            
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
