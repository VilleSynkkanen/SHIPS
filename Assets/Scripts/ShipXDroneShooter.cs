using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipXDroneShooter : ChargedShooter
{
    [SerializeField] PlayerInput shipInput;

    public override void Shoot()
    {
        foreach(Transform shotLocation in ShotLocations)
        {
            PlayerInput droneInput = PlayerInput.Instantiate(Projectile);
            droneInput.SwitchCurrentControlScheme(shipInput.currentControlScheme);
            droneInput.transform.position = shotLocation.position;
            droneInput.transform.rotation = shotLocation.rotation;
        }
    }
}
