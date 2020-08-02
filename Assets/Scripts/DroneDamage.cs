using UnityEngine;

public class DroneDamage : MonoBehaviour, ICollision
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float maxHp;
    [SerializeField] ProjectileCollision drone;
    
    float hp;

    void Awake()
    {
        hp = maxHp;
    }

    public void Collision(ProjectileCollision collider)
    {
        Vector2 velocity = collider.rb.velocity;
        Vector2 position = new Vector2(collider.transform.position.x, collider.transform.position.y);
        rb.AddExplosionForce(collider.ExplosionForce, position);
        TakeDamage(collider.CalculateDamage(velocity));
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            drone.Destruction();
        }
    }
}
