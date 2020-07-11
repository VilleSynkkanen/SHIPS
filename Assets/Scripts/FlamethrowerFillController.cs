using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlamethrowerFillController : MonoBehaviour
{
    [SerializeField] Image[] fills;
    [SerializeField] FlamethrowerShooter shooter;
    [SerializeField] bool[] fillOnOverheat;
    [SerializeField] GameObject arrow;


    void Update()
    {
        for(int i = 0; i < fills.Length; i++)
        {
            if (shooter.overheated && fillOnOverheat[i])
                fills[i].fillAmount = 1;
            else
                fills[i].fillAmount = shooter.heat;
        }
    }

    public void DeactivateArrow()
    {
        for (int i = 0; i < fills.Length; i++)
        {
            fills[i].fillAmount = 1;
        }
        arrow.SetActive(false);
    }
}
