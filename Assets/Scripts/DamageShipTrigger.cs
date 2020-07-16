using System.Collections.Generic;
using UnityEngine;

public class DamageShipTrigger : MonoBehaviour
{
    [SerializeField] DamageShipTriggerData data;
    List<ShipSegment> segments = new List<ShipSegment>();

    private void Update()
    {
        for(int i = 0; i < segments.Count; i++)
        {
            float velocity = segments[i].Rb.velocity.magnitude;
            segments[i].TakeDamage(segments[i].data.TerrainDamageMultiplier * data.BaseDamage 
                * Mathf.Pow(velocity, data.SpeedPower) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShipSegment seg = collision.GetComponent<ShipSegment>();
        if(seg != null)
        {
            segments.Add(seg);
            seg.Ship.Movement.SlowEffect(data.MoveSlowAmount, data.TurningSlowAmount);
            if(data.PlayDamageSound)
                seg.PlayTerrainDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShipSegment seg = collision.GetComponent<ShipSegment>();
        if (seg != null)
        {
            segments.Remove(seg);
            seg.Ship.Movement.EndSlowEffect(data.MoveSlowAmount, data.TurningSlowAmount);
            if (data.PlayDamageSound)
                seg.StopTerrainDamage();
        }
    }
}
