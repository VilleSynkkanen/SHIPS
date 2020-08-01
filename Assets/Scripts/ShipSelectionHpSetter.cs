using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelectionHpSetter : MonoBehaviour
{
    [SerializeField] Image[] defenses;

    void Start()
    {
        SetHitpoints();
    }

    void SetHitpoints()
    {
        for(int i = 0; i < defenses.Length; i++)
        {
            ShipData data = GameSettings.Instance.GetShipData((ShipType)i);
            int front = data.SegmentHp[0];
            int middle = data.SegmentHp[1];
            int rear = data.SegmentHp[2];
            int total = data.MaxHp;
            float defenseValue = 1.5f * (0.9f * total + (0.8f * front + middle + 0.8f * rear) / 3);
            defenses[i].fillAmount = defenseValue / 100;
        }
    }
}
