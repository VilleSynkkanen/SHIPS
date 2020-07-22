﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipXDroneShooter : ChargedShooter
{
    [SerializeField] PlayerInput shipInput;

    DroneShooterData droneData;

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
            ball.tag = "Drone";
            ball.rotation += rotation;
            ball.AddRelativeForce(Vector2.up * chargedData.ShotForce * forceMultiplier);
            shotLocation.gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(ActivateEngine(droneInput.gameObject));

            if (Data.LimitedAmmo)
            {
                ExpendAmmo();
            }

            TriggerShotEvent();
        }
    }

    IEnumerator ActivateEngine(GameObject drone)
    {
        yield return new WaitForSeconds(droneData.EngineDelay);
        drone.GetComponent<TorpedoMovement>().enabled = true;
    }
}
