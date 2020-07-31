using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] Vector3 selectedScale;
    [SerializeField] float animationTime;

    public void OnSelect(BaseEventData eventData)
    {
        LeanTween.scale(gameObject, selectedScale, animationTime).setEase(LeanTweenType.easeOutBack);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        LeanTween.scale(gameObject, Vector3.one, animationTime).setEase(LeanTweenType.easeInBack);
    }
}
