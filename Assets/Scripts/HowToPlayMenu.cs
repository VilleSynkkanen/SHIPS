using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayMenu : MonoBehaviour
{
    [SerializeField] GameObject[] tips;
    [SerializeField] Button previous;
    [SerializeField] Button next;
    int i;

    void Awake()
    {
        i = 0;
        CheckActiveButtons();
    }

    public void Previous()
    {
        if(i > 0)
        {
            tips[i].SetActive(false);
            i--;
            tips[i].SetActive(true);
            CheckActiveButtons();
        }
    }

    public void Next()
    {
        if (i + 1 < tips.Length)
        {
            tips[i].SetActive(false);
            i++;
            tips[i].SetActive(true);
            CheckActiveButtons();
        }
    }

    void CheckActiveButtons()
    {
        if(i == 0)
        {
            previous.interactable = false;
        }
        else
        {
            previous.interactable = true;
        }

        if (i + 1 == tips.Length)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;
        }
    }
}