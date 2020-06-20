using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    public ShipMovement movement { get; private set; }
    public ShipShooterManager shooter { get; private set; }
    public AimControl aim { get; private set; }

    private void Awake()
    {
        movement = GetComponent<ShipMovement>();
        shooter = GetComponent<ShipShooterManager>();
        aim = GetComponent<AimControl>();
    }

    public void Activate()
    {
        movement.enabled = true;
        shooter.enabled = true;
        aim.enabled = true;
    }
}
