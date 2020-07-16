using UnityEngine;

[CreateAssetMenu]
public class ProjectileGravityData : ScriptableObject
{
    [SerializeField] float acceleration;
    [SerializeField] float startingAltitude;

    public float Acceleration { get => acceleration; }
    public float StartingAltitude { get => startingAltitude; }
}
