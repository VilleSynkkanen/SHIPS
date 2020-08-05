using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ScrollableMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup[] tips;
    [SerializeField] float fadeTime;
    [SerializeField] float fadeDelayTime;
    protected int i;
    
    public void Awake()
    {
        i = 0;
    }

    public void Previous()
    {
        StartCoroutine(PreviousDelayed());
    }

    IEnumerator PreviousDelayed()
    {
        LeanTween.alphaCanvas(tips[i], 0, fadeTime);
        i--;
        yield return new WaitForSeconds(fadeDelayTime);
        if (i == -1)
        {
            i = tips.Length - 1;
            LeanTween.alphaCanvas(tips[i], 1, fadeTime);
        }
        else
        {
            LeanTween.alphaCanvas(tips[i], 1, fadeTime);
        }
    }

    public void Next()
    {
        StartCoroutine(NextDelayed());
    }

    IEnumerator NextDelayed()
    {
        LeanTween.alphaCanvas(tips[i], 0, fadeTime);
        i++;
        yield return new WaitForSeconds(fadeDelayTime);
        if (i == tips.Length)
        {
            i = 0;
            LeanTween.alphaCanvas(tips[i], 1, fadeTime);
        }
        else
        {
            LeanTween.alphaCanvas(tips[i], 1, fadeTime);
        }
    }

    public void ActivateMenu(int index)
    {
        StartCoroutine(ActivateDelayed(index));
    }

    IEnumerator ActivateDelayed(int index)
    {
        LeanTween.alphaCanvas(tips[i], 0, fadeTime);
        i = index;
        yield return new WaitForSeconds(fadeDelayTime);
        LeanTween.alphaCanvas(tips[i], 1, fadeTime);
    }
}