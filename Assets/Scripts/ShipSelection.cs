using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public enum InputType { previous, next};
public class ShipSelection : MonoBehaviour
{
    [SerializeField] CanvasGroup[] ships;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] RectTransform rectTrans;
    [SerializeField] PlayerColorController colorController;
    [SerializeField] RectTransform[] shipImages;
    [SerializeField] int[] startingPositionY;
    [SerializeField] float animationTime;
    [SerializeField] LeanTweenType joinType;
    [SerializeField] LeanTweenType leaveType;
    [SerializeField] float fadeTime;
    [SerializeField] float fadeInterval;
    [SerializeField] LeanTweenType fadeInType;
    [SerializeField] LeanTweenType fadeOutType;
    int uiPosition;
    
    List<InputType> inputQueue = new List<InputType>();
    public int i { get; private set; }
    public float AnimationTime { get => animationTime; }
    public RectTransform[] ShipImages { get => shipImages; }

    bool switching;

    private void Awake()
    {
        i = 0;
        switching = false;
    }

    void CheckInputQueue()
    {
        if(inputQueue.Count > 0)
        {
            InputType type = inputQueue[0];
            inputQueue.RemoveAt(0);
            if (type == InputType.next)
                NextShip();
            else
                PreviousShip();
        }
    }

    public void SetPlayerText(string txt)
    {
        text.text = txt;
    }
    
    void AddToInputQueue(InputType type)
    {
        if(inputQueue.Count < 4)
            inputQueue.Add(type);
    }
    
    public void NextShip()
    {
        if(!switching)
        {
            switching = true;
            StartCoroutine(SetActive(ships[i], false));
            i++;
            if (i == ships.Length)
            {
                i = 0;
                StartCoroutine(SetActive(ships[i], true));
            }
            else
            {
                StartCoroutine(SetActive(ships[i], true));
            }
        }
        else
        {
            AddToInputQueue(InputType.next);
        }
    }

    public void PreviousShip()
    {
        if (!switching)
        {
            switching = true;
            StartCoroutine(SetActive(ships[i], false));
            i--;
            if (i == -1)
            {
                i = ships.Length - 1;
                StartCoroutine(SetActive(ships[i], true));
            }
            else
            {
                StartCoroutine(SetActive(ships[i], true));
            }
        }
        else
        {
            AddToInputQueue(InputType.previous);
        }
    }

    IEnumerator SetActive(CanvasGroup group, bool state)
    {
        if (state)
        {
            yield return new WaitForSeconds(fadeInterval);
            LeanTween.alphaCanvas(group, 1, fadeTime).setEase(fadeInType);
            StartCoroutine(SetSwitching(fadeTime));
        }
        else
        {
            LeanTween.alphaCanvas(group, 0, fadeTime).setEase(fadeOutType);
        }
    }

    IEnumerator SetSwitching(float time)
    {
        yield return new WaitForSeconds(time);
        switching = false;
        CheckInputQueue();
    }

    public void CheckUIPosition(int index)
    {
        if(index != uiPosition)
        {
            UnjoinAnimation(uiPosition);
            StartCoroutine(SetUIDelayed(animationTime, index));
        }
    }

    IEnumerator SetUIDelayed(float delay, int index)
    {
        yield return new WaitForSeconds(delay);
        SetUI(index);
    }
    
    public void SetUI(int index, bool ready=false)
    {
        uiPosition = index;
        Vector2 pivot;
        Vector2 anchorMin;
        Vector2 anchorMax;

        if (index == 0)
        {
            pivot = Vector2.zero;
            anchorMin = Vector2.zero;
            anchorMax = Vector2.zero;
        }
        else if (index == 1)
        {
            pivot = Vector2.right;
            anchorMin = Vector2.right;
            anchorMax = Vector2.right;
        }
        else if (index == 2)
        {
            pivot = Vector2.up;
            anchorMin = Vector2.up;
            anchorMax = Vector2.up;
        }
        else
        {
            pivot = Vector2.right + Vector2.up;
            anchorMin = Vector2.right + Vector2.up;
            anchorMax = Vector2.right + Vector2.up;
        }

        rectTrans.pivot = pivot;
        rectTrans.anchoredPosition = new Vector3(0, startingPositionY[index], 0);
        rectTrans.anchorMin = anchorMin;
        rectTrans.anchorMax = anchorMax;

        if(!ready)
            SetPlayerText("PLAYER " + (index + 1).ToString() + " JOINED");
        else
            SetPlayerText("PLAYER " + (index + 1).ToString() + " READY");
        colorController.UpdateColor();

        LeanTween.moveY(rectTrans, 0, AnimationTime).setEase(joinType);
    }

    public void UnjoinAnimation(int index)
    {
        if(index < startingPositionY.Length) 
            LeanTween.moveY(rectTrans, startingPositionY[index], animationTime).setEase(leaveType);
    }
}
