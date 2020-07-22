using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipXMineData : ScriptableObject
{
    [SerializeField] float moveSlowAmount;
    [SerializeField] float turnSlowAmount;
    [SerializeField] float moveSpeedupAmount;
    [SerializeField] float turnSpeedupAmount;

    public float MoveSlowAmount { get => moveSlowAmount; }
    public float TurnSlowAmount { get => turnSlowAmount; }
    public float MoveSpeedupAmount { get => moveSpeedupAmount; }
    public float TurnSpeedupAmount { get => turnSpeedupAmount; }
}
