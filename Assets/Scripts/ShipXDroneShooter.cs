using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipXDroneShooter : ChargedShooter
{
    [SerializeField] PlayerInput shipInput;
    [SerializeField] SpriteRenderer shipSprite;
    ShipXDrone drone;
    DroneShooterData droneData;
    Collider2D droneCollider;
    Rigidbody2D droneRb;
    bool droneDestroyed;

    private new void Start()
    {
        base.Start();
        droneData = (DroneShooterData)Data;
        SpawnDrone();
    }

    void SpawnDrone()
    {
        Vector3 location = new Vector3(1000, 1000, 0);
        PlayerInput droneInput = Instantiate(Projectile, location, Quaternion.identity).GetComponent<PlayerInput>();
        droneInput.SwitchCurrentControlScheme(shipInput.currentControlScheme);
        drone = droneInput.GetComponent<ShipXDrone>();
        drone.SetShooter(this);
        droneRb = drone.GetComponent<Rigidbody2D>();
        droneCollider = drone.GetComponent<Collider2D>(); 
        droneCollider.enabled = false;
        drone.tag = tag;
    }

    public void DroneDestroyed()
    {
        droneDestroyed = true;
        HideDrone();
    }

    void HideDrone()
    {
        Vector3 location = new Vector3(1000, 1000, 0);
        drone.transform.position = location;
        droneRb.velocity = Vector2.zero;
        droneRb.angularVelocity = 0;
        droneCollider.enabled = false;
    }
    
    public override void Shoot()
    {
        foreach(Transform shotLocation in ShotLocations)
        {
            float forceMultiplier = Random.Range(chargedData.MinForce, chargedData.MaxForce);
            float rotation = Random.Range(-chargedData.RotationVariation, chargedData.RotationVariation);

            drone.transform.position = shotLocation.position;
            drone.transform.rotation = shotLocation.rotation;
            drone.StartLife();
            droneCollider.enabled = true;
            droneRb.rotation += rotation;
            droneRb.AddRelativeForce(Vector2.up * chargedData.ShotForce * forceMultiplier);
            drone.GetComponent<CannonShooter>().ResetState();
            shotLocation.gameObject.GetComponent<AudioSource>().Play();
            shotLocation.tag = tag;
            StartCoroutine(ActivateEngine(drone.gameObject));

            if (Data.LimitedAmmo)
            {
                ExpendAmmo();
            }

            TriggerShotEvent();
        }
    }

    public IEnumerator ActivateEngine(GameObject drone)
    {
        droneDestroyed = false;
        ShipXDrone dro = drone.GetComponent<ShipXDrone>();
        yield return new WaitForSeconds(droneData.EngineDelay);
        if(dro != null && !droneDestroyed)
        {
            dro.ActivateDrone(shipSprite.color);
        }
            
    }
}
