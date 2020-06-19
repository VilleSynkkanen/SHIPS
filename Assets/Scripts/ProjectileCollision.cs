using UnityEngine;

public enum ProjectileType { cannonball, mine}
public class ProjectileCollision : MonoBehaviour
{
    ProjectileData data;
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionTravel;
    int dmg;
    [SerializeField] ProjectileType type;
    
    public Rigidbody2D rb { get; private set; }
    public float ExplosionForce { get => data.explosionForce; }

    private void Awake()
    {
        // make better solution later for different projectiles

        if (type == ProjectileType.cannonball)
        {
            data = GameSettings.Instance.CannonballProjectileData;
        }
        else if(type == ProjectileType.mine)
        {
            data = GameSettings.Instance.MineProjectileData;
        }
        rb = GetComponent<Rigidbody2D>();
        dmg = data.dmg;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ICollision collisionObject = collision.gameObject.GetComponent<ICollision>();
        if (collisionObject != null && collision.tag != gameObject.tag)
        {
            collisionObject.Collision(this);
            dmg = 0;
            Vector3 explosionPosition = rb.velocity * explosionTravel;
            if(collision.tag != "Boundary")    
                Instantiate(explosion, transform.position + explosionPosition, transform.rotation);
            Destroy(gameObject);
        }
    }

    public float CalculateDamage(Vector2 velocity)
    {
        float magnitude = velocity.magnitude;
        float damage = data.angleCoefficient * magnitude + data.minDamage;

        return damage * dmg;    // multiply coefficient by base dmg
    } 
}