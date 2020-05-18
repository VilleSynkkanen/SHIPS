using UnityEngine;
using UnityEngine.Events;

public enum SegmentType { Front, Middle, Back}

public class ShipSegment : MonoBehaviour, ICollision
{
    [SerializeField] SegmentType type;
    [SerializeField] int maxHp;
    [SerializeField] Rigidbody2D rb;    //rigidbody of ship
    [SerializeField] ShipDamage ship;
    public float hp { get; private set; }
    public int MaxHp { get => maxHp; }
    public event UnityAction<float, SegmentType> damageTaken = delegate { };

    void Awake()
    {
        hp = MaxHp;
        damageTaken += ship.TakeDamage;
    }
    
    public void Collision(ProjectileCollision collider)
    {
        Vector2 velocity = collider.rb.velocity;
        Vector2 position = new Vector2(collider.transform.position.x, collider.transform.position.y);
        rb.AddExplosionForce(collider.ExplosionForce, position);
        TakeDamage(collider.CalculateDamage(velocity));
    }

    void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp < 0)
            hp = 0;
        damageTaken(amount, type);
    }

    void OnDestroy()
    {
        damageTaken -= ship.TakeDamage;
    }
}