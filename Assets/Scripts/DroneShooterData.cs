using UnityEngine;

[CreateAssetMenu]
public class DroneShooterData : ChargedShooterData
{
    [SerializeField] float engineDelay;

    public float EngineDelay { get => engineDelay; }
}
