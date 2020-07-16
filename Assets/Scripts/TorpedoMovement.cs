using UnityEngine;

public class TorpedoMovement : MonoBehaviour
{
    [SerializeField] float force;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * force * Time.fixedDeltaTime);
    }
}
