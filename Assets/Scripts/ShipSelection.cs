using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelection : MonoBehaviour
{
    [SerializeField] GameObject[] ships;
    public int i { get; private set; }

    private void Awake()
    {
        i = 0;
    }

    public void NextShip()
    {
        ships[i].SetActive(false);
        i++;
        if (i == ships.Length)
        {
            i = 0;
            ships[i].SetActive(true);
        }
        else
        {
            ships[i].SetActive(true);
        }
    }

    public void PreviousShip()
    {
        ships[i].SetActive(false);
        i--;
        if (i == -1)
        {
            i = ships.Length - 1;
            ships[i].SetActive(true);
        }
        else
        {
            ships[i].SetActive(true);
        }
    }
}
