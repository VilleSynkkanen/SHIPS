using UnityEngine;

public class ShipXDrone : MonoBehaviour
{
    [SerializeField] PlayerControlInput controls;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] ShooterType type;
    [SerializeField] TorpedoMovement movement;
    [SerializeField] CannonShooter shooter;
    [SerializeField] ProjectileCollision collision;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] ParticleSystem[] engines;
    [SerializeField] float shotCheckRange;

    DroneProjectileData data;
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
                transform.up, shotCheckRange, mask);
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

        foreach(ParticleSystem engine in engines)
        {
            engine.Play();
        }
    }

    public void Destruction()
    {
        collision.DestructionEffect();
    }
}
