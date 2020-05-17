using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] int dmg;
    [SerializeField] float angleCoefficient;
    [SerializeField] float minDamage;
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionTravel;
    public Rigidbody2D rb { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ICollision collisionObject = collision.gameObject.GetComponent<ICollision>();
        if (collisionObject != null && collision.tag != gameObject.tag)
        {
            collisionObject.Collision(this);
            dmg = 0;
            Vector3 explosionPosition = rb.velocity * explosionTravel;
            Instantiate(explosion, transform.position + explosionPosition, transform.rotation);
            Destroy(gameObject);
        }
    }

    public float CalculateDamage(Vector2 velocity)
    {
        // if velocity 0, damage is 50%
        // if is 5, dmg is 150%

        float magnitude = velocity.magnitude;
        float damage = angleCoefficient * magnitude + minDamage;

        return damage * dmg;    // multiply coefficient by base dmg
    } 
}