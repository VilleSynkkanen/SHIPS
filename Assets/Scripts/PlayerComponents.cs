using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    public ShipMovement movement { get; private set; }
    public ShipShooter shooter { get; private set; }
    public ShipLayMine mine { get; private set; }
    public FrontCannonControl aim { get; private set; }

    private void Awake()
    {
        movement = GetComponent<ShipMovement>();
        shooter = GetComponent<ShipShooter>();
        mine = GetComponent<ShipLayMine>();
        aim = GetComponent<FrontCannonControl>();
    }

    public void Activate()
    {
        movement.enabled = true;
        shooter.enabled = true;
        aim.enabled = true;
        mine.enabled = true;
    }
}
