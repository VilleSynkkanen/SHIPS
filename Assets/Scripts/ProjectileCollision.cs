﻿using UnityEngine;
using UnityEngine.Events;

public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionTravel;
    [SerializeField] ShooterType type;
    [SerializeField] bool boundaryCollision;
    [SerializeField] bool fireEventOnDestruction;
    [SerializeField] bool letEventHandleDestruction;
    [SerializeField] UnityEvent OnDestruction;

    float dmg;
    
    public ProjectileData data { get; private set; }
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
                Destruction();
            }    
            else if(collision.tag == "Boundary" && boundaryCollision)
                Destruction();
        }
    }

    public void DestructionEffect()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void Destruction()
    {  
        if(fireEventOnDestruction)
            OnDestruction.Invoke();
        if(!fireEventOnDestruction || !letEventHandleDestruction)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 10);
        }
    }

    public float CalculateDamage(Vector2 velocity)
    {
        float magnitude = velocity.magnitude;
        float damage = data.AngleCoefficient * magnitude + data.MinDamage;

        // multiply coefficient by base dmg
        return damage * dmg;    
    } 
}