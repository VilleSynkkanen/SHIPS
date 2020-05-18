using UnityEngine;
using UnityEngine.UI;

public class ScrollableMenu : MonoBehaviour
{
    [SerializeField] GameObject[] tips;
    [SerializeField] Button previous;
    [SerializeField] Button next;
    [SerializeField] bool goesAround;
    int i;
    void Awake()
    {
        i = 0;
        CheckActiveButtons();
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
        CheckActiveButtons();
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
        CheckActiveButtons();
    }

    void CheckActiveButtons()
    {
        if(!goesAround)
        {
            if (i == 0)
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
}