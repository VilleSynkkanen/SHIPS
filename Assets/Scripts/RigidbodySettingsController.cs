using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodySettingsController : MonoBehaviour
{
    Rigidbody2D rb;
    RigidbodyData data;
    [SerializeField] ShipType type;

    private void Awake()
    {
        data = GameSettings.Instance.GetShipRigidbodyData(type);
        rb = GetComponent<Rigidbody2D>();
        rb.mass = data.Mass;
        rb.drag = data.LinearDrag;
        rb.angularDrag = data.AngularDrag;
    }
}
