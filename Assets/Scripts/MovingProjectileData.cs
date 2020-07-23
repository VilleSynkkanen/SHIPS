using UnityEngine;

[CreateAssetMenu]
public class MovingProjectileData : ProjectileData
{
    [SerializeField] float force;

    public float Force { get => force; }
}
