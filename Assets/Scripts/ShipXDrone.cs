using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipXDrone : MonoBehaviour
{
    [SerializeField] PlayerControlInput controls;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] ShooterType type;
    DroneProjectileData data;
    [SerializeField] TorpedoMovement movement;
    [SerializeField] CannonShooter shooter;
    [SerializeField] ProjectileCollision collision;
    [SerializeField] SpriteRenderer sprite;
    float aim;
    bool shoot;

    private void Awake()
    {
        data = (DroneProjectileData)GameSettings.Instance.GetProjectileData(type);
        shoot = false;
    }

    private void Start()
    {
        Invoke("Destruction", data.Lifetime);
    }

    private void Update()
    {
        aim = controls.aim;
        DetermineShooting();
    }

    void DetermineShooting()
    {
        if (shoot)
        {
            LayerMask mask = LayerMask.GetMask("Ships", "Land");
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(shooter.ShotLocations[0].position.x, shooter.ShotLocations[0].position.y),
                transform.up, Mathf.Infinity, mask);
            if (hit)
            {
                ShipSegment segment = hit.collider.GetComponent<ShipSegment>();
                if (segment != null && segment.tag != tag)
                {
                    shooter.ShotInput(true);
                    return;
                }
            }
        }

        shooter.ShotInput(false);
    }

    private void FixedUpdate()
    {
        rb.SetRotation(rb.rotation - aim * data.TurnSpeed * Time.fixedDeltaTime);
        rb.velocity = transform.up * rb.velocity.magnitude;
    }

    public void ActivateDrone(Color color)
    {
        movement.enabled = true;
        shoot = true;
        sprite.color = color;
    }

    public void Destruction()
    {
        collision.DestructionEffect();
    }
}
