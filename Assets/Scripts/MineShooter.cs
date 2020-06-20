using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineShooter : InstantShooter
{
    MineShooterData mineData;
    
    void Start()
    {
        mineData = (MineShooterData)Data;
    }

    public override void Shoot()
    {
        foreach (Transform location in ShotLocations)
        {
            GameObject mine = Instantiate(Projectile, location.position, location.rotation);
            mine.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * Data.shotForce);
            StartCoroutine(ActivateCollider(mine.GetComponent<Collider2D>()));
            location.gameObject.GetComponent<AudioSource>().Play();

            if (Data.limitedAmmo)
            {
                ExpendAmmo();
            }
        }

        TriggerShotEvent();
    }

    IEnumerator ActivateCollider(Collider2D collider)
    {
        yield return new WaitForSeconds(mineData.activationDelay);
        collider.enabled = true;
    }
}
