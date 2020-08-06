using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] bool deselectOnPointerExit;
    [SerializeField] Vector3 selectedScale;
    [SerializeField] float animationTime;
    [SerializeField] LeanTweenType selectType;
    [SerializeField] LeanTweenType deselectType;

    public void OnSelect(BaseEventData eventData)
    {
        LeanTween.scale(gameObject, selectedScale, animationTime).setEase(selectType);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        LeanTween.scale(gameObject, Vector3.one, animationTime).setEase(deselectType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventSystem.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(deselectOnPointerExit)
            eventSystem.SetSelectedGameObject(null);
    }
}
