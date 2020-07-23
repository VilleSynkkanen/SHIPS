using UnityEngine;

public class TorpedoMovement : MonoBehaviour
{
    [SerializeField] ProjectileCollision collision;
    Rigidbody2D rb;
    MovingProjectileData data;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        data = (MovingProjectileData)collision.data;
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * data.Force * Time.fixedDeltaTime);
    }
}
