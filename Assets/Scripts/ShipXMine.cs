using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipXMine : MonoBehaviour
{
    List<ShipMovement> ships = new List<ShipMovement>();
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float spriteAlpha;
    ShipXMineData data;

    void Awake()
    {
        data = GameSettings.Instance.ShipXMineData;
    }

    public void SetColor(Color color)
    {
        sprite.color = new Color(color.r, color.g, color.b, spriteAlpha);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShipMovement mov = collision.GetComponent<ShipMovement>();
        if (mov != null)
        {
            ships.Add(mov);
            if (mov.tag == tag)
            {
                mov.SlowEffect(-data.MoveSpeedupAmount, -data.TurnSpeedupAmount);
            }
            else
            { 
                mov.SlowEffect(data.MoveSlowAmount, data.TurnSlowAmount);
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
                mov.EndSlowEffect(-data.MoveSpeedupAmount, -data.TurnSpeedupAmount);
            }
            else
            {
                mov.EndSlowEffect(data.MoveSlowAmount, data.TurnSlowAmount);
            }
        }
    }
}
