using System.Collections;
using System.Collections.Generic;
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
        yield return new WaitForSeconds(torpData.LaunchDelay);

        foreach (Transform location in ShotLocations)
        {
            GameObject clone = Instantiate(Projectile, location.position, location.rotation);
            clone.transform.SetProjectileParent();
            clone.tag = tag;
            Rigidbody2D projectile = clone.GetComponent<Rigidbody2D>();
            location.gameObject.GetComponent<AudioSource>().Play();

            if (Data.LimitedAmmo)
            {
                ExpendAmmo();
            }
        }

        TriggerShotEvent();
    }
}
