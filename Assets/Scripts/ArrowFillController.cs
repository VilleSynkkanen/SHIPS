using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowFillController : MonoBehaviour
{
    [SerializeField] ChargedShooter[] shooters;
    [SerializeField] GameObject[] arrows;
    [SerializeField] Image[] arrowFills;

    void Update()
    {
        UpdateFills();
    }

    void UpdateFills()
    {
        for (int i = 0; i < shooters.Length; i++)
        {
            arrowFills[i].fillAmount = shooters[i].shotCharge;
            if (shooters[i].cooldownLeft <= 0)
            {
                arrows[i].SetActive(true);
            }
        }
    }

    public void DeactivateFill(int i)
    {
        arrows[i].SetActive(false);
    }
}
