using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FlamethrowerShooterData : ShooterData
{
    [SerializeField] float damagePerTick;
    [SerializeField] float heatPerTick;
    [SerializeField] float heatDissipation;
    [SerializeField] float heatDissipationDelay;

    public float DamagePerTick { get => damagePerTick; }
    public float HeatPerTick { get => heatPerTick; }
    public float HeatDissipation { get => heatDissipation; }
    public float HeatDissipationDelay { get => heatDissipationDelay; }
}
