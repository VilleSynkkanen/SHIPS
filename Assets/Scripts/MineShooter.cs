using System.Collections;
using UnityEngine;

public class MineShooter : InstantShooter
{
    [SerializeField] bool giveFriendlyTagAndColor;
    [SerializeField] SpriteRenderer ship;

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
            mine.transform.SetProjectileParent();
            mine.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * Data.ShotForce);
            StartCoroutine(ActivateCollider(mine.GetComponent<Collider2D>()));
            location.gameObject.GetComponent<AudioSource>().Play();
            if (giveFriendlyTagAndColor)
            {
                mine.tag = tag;
            }
                
            if (Data.LimitedAmmo)
            {
                ExpendAmmo();
            }
        }

        TriggerShotEvent();
    }

    IEnumerator ActivateCollider(Collider2D collider)
    {
        yield return new WaitForSeconds(mineData.ActivationDelay);
        collider.enabled = true;
        if(giveFriendlyTagAndColor)
        {
            ShipXMine proj = collider.GetComponent<ShipXMine>();
            if (proj != null)
                proj.SetColor(ship.color);
        }
    }
}
