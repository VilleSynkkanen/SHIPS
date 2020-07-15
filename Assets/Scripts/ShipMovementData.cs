using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipMovementData : ScriptableObject
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float steeringSpeed;
    [SerializeField] float throttleSpeed;
    [SerializeField] float reverseSpeed;
    [SerializeField] float damageAngleCoefficient;
    [SerializeField] float maxDamageEffect;
    [SerializeField] float turningPenaltyTreshold;
    [SerializeField] float maxTurningPenalty;

    public float MoveSpeed { get => moveSpeed; }
    public float TurnSpeed { get => turnSpeed; }
    public float SteeringSpeed { get => steeringSpeed; }
    public float ThrottleSpeed { get => throttleSpeed; }
    public float ReverseSpeed { get => reverseSpeed; }
    public float DamageAngleCoefficient { get => damageAngleCoefficient; }
    public float MaxDamageEffect { get => maxDamageEffect; }
    public float TurningPenaltyTreshold { get => turningPenaltyTreshold; }
    public float MaxTurningPenalty { get => maxTurningPenalty; }
}
