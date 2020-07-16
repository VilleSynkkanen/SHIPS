using UnityEngine;

[CreateAssetMenu]
public class ShipData : ScriptableObject
{
    [SerializeField] int maxHp;
    [SerializeField] int[] segmentHp;
    [SerializeField] float terrainDamageMultiplier;

    public int MaxHp { get => maxHp; }
    public int[] SegmentHp { get => segmentHp; }
    public float TerrainDamageMultiplier { get => terrainDamageMultiplier; }
}
