using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    public ShipMovement movement { get; private set; }
    public ShipShooterManager shooter { get; private set; }
    public AimControl aim { get; private set; }
    public ShipDamage damage { get; private set; }
    public AmmoTextController[] ammoTexts { get; private set; }

    private void Awake()
    {
        movement = GetComponent<ShipMovement>();
        shooter = GetComponent<ShipShooterManager>();
        aim = GetComponent<AimControl>();
        damage = GetComponent<ShipDamage>();
        ammoTexts = GetComponents<AmmoTextController>();
    }

    public void Activate()
    {
        movement.enabled = true;
        shooter.enabled = true;
        aim.enabled = true;
    }

    public void Deactivate()
    {
        movement.enabled = false;
        shooter.enabled = false;
        aim.enabled = false;
    }
}
