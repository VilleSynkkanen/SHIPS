using UnityEngine;

[CreateAssetMenu]
public class DroneProjectileData : MovingProjectileData
{
    [SerializeField] float turnSpeed;
    [SerializeField] float lifetime;

    public float TurnSpeed { get => turnSpeed; }
    public float Lifetime { get => lifetime; }
}
