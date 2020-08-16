using UnityEngine;
using System.Collections;

public class ScrollableMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup[] tips;
    [SerializeField] float fadeTime;
    [SerializeField] float fadeDelayTime;
    [SerializeField] bool deactivateObjects;
    
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
        GameObject deactivate = tips[i].gameObject;
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
        if (deactivateObjects)
            tips[i].gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeTime - fadeDelayTime);
        if (deactivateObjects)
            deactivate.SetActive(false);

    }

    public void Next()
    {
        StartCoroutine(NextDelayed());
    }

    IEnumerator NextDelayed()
    {
        GameObject deactivate = tips[i].gameObject;
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
        if (deactivateObjects)
            tips[i].gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeTime - fadeDelayTime);
        if (deactivateObjects)
            deactivate.SetActive(false);
    }

    public void ActivateMenu(int index)
    {
        if(index != i)
            StartCoroutine(ActivateDelayed(index));
    }

    IEnumerator ActivateDelayed(int index)
    {
        GameObject deactivate = tips[i].gameObject;
        LeanTween.alphaCanvas(tips[i], 0, fadeTime);
        i = index;
        yield return new WaitForSeconds(fadeDelayTime);
        LeanTween.alphaCanvas(tips[i], 1, fadeTime);
        if (deactivateObjects)
            tips[i].gameObject.SetActive(true);
        yield return new WaitForSeconds(fadeTime - fadeDelayTime);
        if (deactivateObjects)
            deactivate.SetActive(false);
    }
}