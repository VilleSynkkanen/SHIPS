using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MineData : ScriptableObject
{
    public float shotForce;
    public float shotCooldown;
    public int startingMines;
    public float activationDelay;
}
