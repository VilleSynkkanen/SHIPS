using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerCollider : MonoBehaviour
{
    List<ShipSegment> segments = new List<ShipSegment>();

    public List<ShipSegment> Segments { get => segments; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShipSegment seg = collision.GetComponent<ShipSegment>();
        if (seg != null)
        {
            Segments.Add(seg);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShipSegment seg = collision.GetComponent<ShipSegment>();
        if (seg != null)
        {
            Segments.Remove(seg);
        }
    }
}
