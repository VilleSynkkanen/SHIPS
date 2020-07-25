using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipXMine : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float spriteAlpha;
    [SerializeField] Transform model;

    ShipXMineData data;
    List<ShipMovement> ships = new List<ShipMovement>();

    void Awake()
    {
        data = GameSettings.Instance.ShipXMineData;
        transform.localScale = new Vector3(data.MineScale, data.MineScale, 1);
        model.localScale = new Vector3(0.75f / data.MineScale, 0.75f / data.MineScale, 1);
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
