using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollableMenu : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject[] tips;
    int i;
    
    void Awake()
    {
        i = 0;
    }

    public void Previous()
    {
        tips[i].SetActive(false);
        i--;
        if (i == -1)
        {
            i = tips.Length - 1;
            tips[i].SetActive(true);
        }
        else
        {
            tips[i].SetActive(true);
        }
    }

    public void Next()
    {
        tips[i].SetActive(false);
        i++;
        if(i == tips.Length)
        {
            i = 0;
            tips[i].SetActive(true);
        }
        else
        {
            tips[i].SetActive(true);
        }
    }

    public void ActivateMenu(int index)
    {
        tips[i].SetActive(false);
        i = index;
        tips[i].SetActive(true);
    }
}