using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipXDroneShooter : ChargedShooter
{
    [SerializeField] PlayerInput shipInput;
    [SerializeField] SpriteRenderer shipSprite;

    DroneShooterData droneData;
    bool droneDestroyed;

    private new void Start()
    {
        base.Start();
        droneData = (DroneShooterData)Data;
    }

    public override void Shoot()
    {
        foreach(Transform shotLocation in ShotLocations)
        {
            float forceMultiplier = Random.Range(chargedData.MinForce, chargedData.MaxForce);
            float rotation = Random.Range(-chargedData.RotationVariation, chargedData.RotationVariation);

            PlayerInput droneInput = Instantiate(Projectile, shotLocation.position, shotLocation.rotation).GetComponent<PlayerInput>();
            droneInput.SwitchCurrentControlScheme(shipInput.currentControlScheme);
            droneInput.transform.SetProjectileParent();
            Rigidbody2D ball = droneInput.GetComponent<Rigidbody2D>();
            ball.tag = tag;
            ball.rotation += rotation;
            ball.AddRelativeForce(Vector2.up * chargedData.ShotForce * forceMultiplier);
            shotLocation.gameObject.GetComponent<AudioSource>().Play();
            shotLocation.tag = tag;
            StartCoroutine(ActivateEngine(droneInput.gameObject));

            if (Data.LimitedAmmo)
            {
                ExpendAmmo();
            }

            TriggerShotEvent();
        }
    }

    public void DroneDestroyed()
    {
        droneDestroyed = true;
    }

    public IEnumerator ActivateEngine(GameObject drone)
    {
        droneDestroyed = false;
        ShipXDrone dro = drone.GetComponent<ShipXDrone>();
        dro.SetShooter(this);
        yield return new WaitForSeconds(droneData.EngineDelay);
        if(dro != null && !droneDestroyed)
        {
            dro.ActivateDrone(shipSprite.color);
            print("activated");
        }
            
    }
}
