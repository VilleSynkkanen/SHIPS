using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipXDrone : MonoBehaviour
{
    [SerializeField] PlayerControlInput controls;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] ShooterType type;
    DroneProjectileData data;
    float aim;

    private void Awake()
    {
        data = (DroneProjectileData)GameSettings.Instance.GetProjectileData(type);
    }

    private void Start()
    {
        Invoke("Destruction", data.Lifetime);
    }

    private void Update()
    {
        aim = controls.aim;
    }

    private void FixedUpdate()
    {
        rb.SetRotation(rb.rotation - aim * data.TurnSpeed * Time.fixedDeltaTime);
        rb.velocity = transform.up * rb.velocity.magnitude;
    }

    void Destruction()
    {
        Destroy(gameObject);
        // explosion effect
    }
}
