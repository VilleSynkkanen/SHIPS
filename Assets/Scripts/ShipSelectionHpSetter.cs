using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipSelectionHpSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] fronts;
    [SerializeField] TextMeshProUGUI[] middles;
    [SerializeField] TextMeshProUGUI[] rears;
    [SerializeField] TextMeshProUGUI[] totals;

    void Start()
    {
        SetHitpoints();
    }

    void SetHitpoints()
    {
        for(int i = 0; i < totals.Length; i++)
        {
            ShipData data = GameSettings.Instance.GetShipData((ShipType)i);
            fronts[i].text = data.SegmentHp[0].ToString();
            middles[i].text = data.SegmentHp[1].ToString();
            rears[i].text = data.SegmentHp[2].ToString();
            totals[i].text = data.MaxHp.ToString();
        }
    }
}
