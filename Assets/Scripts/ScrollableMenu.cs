using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollableMenu : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject[] tips;
    [SerializeField] Button previous;
    [SerializeField] Button next;
    [SerializeField] bool goesAround;
    int i;
    bool added;
    
    void Awake()
    {
        i = 0;
        added = true;
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
        added = false;
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
        added = true;
        CheckActiveButtons();
    }

    void CheckActiveButtons()
    {
        if(!goesAround)
        {
            if (i == 0)
            {
                previous.interactable = false;
                if (!added)
                    eventSystem.SetSelectedGameObject(next.gameObject);
            }
            else
            {
                previous.interactable = true;
            }

            if (i + 1 == tips.Length)
            {
                next.interactable = false;
                if(added)
                    eventSystem.SetSelectedGameObject(previous.gameObject);
            }
            else
            {
                next.interactable = true;
            }
        }
    }
}