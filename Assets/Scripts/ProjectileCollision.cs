using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] ProjectileData data;
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionTravel;
    int dmg;
    
    public Rigidbody2D rb { get; private set; }
    public float ExplosionForce { get => data.explosionForce; }

    private void Awake()
    {
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