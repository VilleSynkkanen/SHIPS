using UnityEngine;

public class RigidbodySettingsController : MonoBehaviour
{
    [SerializeField] bool ship;
    [SerializeField] ShipType shipType;
    [SerializeField] ShooterType shooterType;

    Rigidbody2D rb;
    RigidbodyData data;

    private void Awake()
    {
        if (ship)
            data = GameSettings.Instance.GetShipRigidbodyData(shipType);
        else
            data = GameSettings.Instance.GetProjectileRigidbodyData(shooterType);
        
        rb = GetComponent<Rigidbody2D>();
        rb.mass = data.Mass;
        rb.drag = data.LinearDrag;
        rb.angularDrag = data.AngularDrag;
    }
}
