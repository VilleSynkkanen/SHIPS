using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionTravel;
    [SerializeField] ShooterType type;
    [SerializeField] bool boundaryCollision;

    ProjectileData data;
    float dmg;

    public Rigidbody2D rb { get; private set; }
    public float ExplosionForce { get => data.ExplosionForce; }

    private void Awake()
    {
        data = GameSettings.Instance.GetProjectileData(type);
        rb = GetComponent<Rigidbody2D>();
        dmg = data.Dmg;
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
            {
                Instantiate(explosion, transform.position + explosionPosition, transform.rotation);
                Destroy(gameObject);
            }    
            else if(collision.tag == "Boundary" && boundaryCollision)
                Destroy(gameObject);
        }
    }

    public float CalculateDamage(Vector2 velocity)
    {
        float magnitude = velocity.magnitude;
        float damage = data.AngleCoefficient * magnitude + data.MinDamage;

        return damage * dmg;    // multiply coefficient by base dmg
    } 
}