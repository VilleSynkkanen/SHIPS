using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoTextController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] ammoTexts;
    [SerializeField] Shooter[] shooters;

    private void Start()
    {
        SetAllAmmoTexts();
    }

    public void SetAmmoText(int i)
    {
        ammoTexts[i].text = shooters[i].ammoLeft.ToString();
    }

    public void SetAllAmmoTexts()
    {
        for (int i = 0; i < ammoTexts.Length; i++)
        {
            ammoTexts[i].text = shooters[i].ammoLeft.ToString();
        }
    }
}
