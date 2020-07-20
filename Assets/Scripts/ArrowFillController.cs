using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowFillController : MonoBehaviour
{
    [SerializeField] ChargedShooter[] shooters;
    [SerializeField] GameObject[] arrows0;
    [SerializeField] GameObject[] arrows1;
    [SerializeField] GameObject[] arrows2;
    [SerializeField] GameObject[] arrows3;
    [SerializeField] Image[] arrowFills0;
    [SerializeField] Image[] arrowFills1;
    [SerializeField] Image[] arrowFills2;
    [SerializeField] Image[] arrowFills3;

    List<GameObject[]> arrows = new List<GameObject[]>();
    List<Image[]> arrowFills = new List<Image[]>();

    private void Awake()
    {
        arrows.Add(arrows0);
        arrows.Add(arrows1);
        arrows.Add(arrows2);
        arrows.Add(arrows3);
        arrowFills.Add(arrowFills0);
        arrowFills.Add(arrowFills1);
        arrowFills.Add(arrowFills2);
        arrowFills.Add(arrowFills3);
    }

    void Update()
    {
        UpdateFills();
    }

    void UpdateFills()
    {
        for (int i = 0; i < shooters.Length; i++)
        {
            for (int j = 0; j < arrows[i].Length; j++)
            {
                arrowFills[i][j].fillAmount = shooters[i].shotCharge;
                if (shooters[i].cooldownLeft <= 0)
                {
                    arrows[i][j].SetActive(true);
                }
            }
        }
    }

    public void DeactivateFill(int i)
    {
        for (int j = 0; j < arrows[i].Length; j++)
        {
            arrows[i][j].SetActive(false);
        }
    }
}
