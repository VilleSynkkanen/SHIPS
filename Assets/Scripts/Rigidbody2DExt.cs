using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rigidbody2DExt
{
    public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition)
    {
        Vector2 explosionDir = (rb.position - explosionPosition).normalized;
        rb.AddForce(explosionForce * explosionDir);
    }
}
