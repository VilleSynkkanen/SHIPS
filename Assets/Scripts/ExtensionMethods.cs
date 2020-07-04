using UnityEngine;

public static class ExtensionMethods
{
    public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition)
    {
        Vector2 explosionDir = (rb.position - explosionPosition).normalized;
        rb.AddForce(explosionForce * explosionDir);
    }

    public static void SetProjectileParent(this Transform trans)
    {
        trans.SetParent(ProjectileParent.instance.transform);
    }
}
