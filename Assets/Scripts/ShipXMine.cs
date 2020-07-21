using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipXMine : MonoBehaviour
{
    List<ShipMovement> ships = new List<ShipMovement>();
    [SerializeField] float moveSlowAmount;
    [SerializeField] float turnSlowAmount;
    [SerializeField] float moveSpeedupAmount;
    [SerializeField] float turnSpeedupAmount;

    void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShipMovement mov = collision.GetComponent<ShipMovement>();
        if (mov != null)
        {
            ships.Add(mov);
            if (mov.tag == tag)
            {
                mov.SlowEffect(-moveSpeedupAmount, -turnSpeedupAmount);
            }
            else
            { 
                mov.SlowEffect(moveSlowAmount, turnSlowAmount);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShipMovement mov = collision.GetComponent<ShipMovement>();
        if (mov != null)
        {
            ships.Remove(mov);
            if (mov.tag == tag)
            {
                mov.EndSlowEffect(-moveSpeedupAmount, -turnSpeedupAmount);
            }
            else
            {
                mov.EndSlowEffect(moveSlowAmount, turnSlowAmount);
            }
        }
    }
}
