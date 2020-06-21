using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipData : ScriptableObject
{
    [SerializeField] int maxHp;
    [SerializeField] int[] segmentHp;

    public int MaxHp { get => maxHp; }
    public int[] SegmentHp { get => segmentHp; }
}
