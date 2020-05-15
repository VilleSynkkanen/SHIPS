using System.Collections;
using System.Collections.Generic;
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
        rb.AddForce(velocity);
        TakeDamage(collider.CalculateDamage(velocity));
    }

    void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp < 0)
            hp = 0;
        damageTaken(amount, type);
    }

    void OnDisable()
    {
        damageTaken -= ship.TakeDamage;
    }
}
