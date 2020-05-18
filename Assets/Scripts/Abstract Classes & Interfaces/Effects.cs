using UnityEngine;

public abstract class Effects : MonoBehaviour
{
    [SerializeField] Color visible;
    [SerializeField] Color invisible;
    [SerializeField] float lerpSpeed;

    public Color Visible { get => visible; }
    public Color Invisible { get => invisible; }
    public float LerpSpeed { get => lerpSpeed; }

    public void ActivateSprite(SpriteRenderer sprite)
    {
        sprite.color = visible;
    }

    public abstract void HandleEffects();
}