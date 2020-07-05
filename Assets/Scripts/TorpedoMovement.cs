using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float force;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * force * Time.fixedDeltaTime);
    }
}
