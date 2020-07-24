using UnityEngine;

public class ShipAnimation : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float animationFadeTreshold;
    [SerializeField] float animationSpeedCoefficient;

    void Update()
    {
        float velocity = rb.velocity.magnitude;
        anim.speed = animationSpeedCoefficient * velocity;
        sprite.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, velocity / animationFadeTreshold));
    }
}
