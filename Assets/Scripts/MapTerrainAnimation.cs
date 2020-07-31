using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTerrainAnimation : MonoBehaviour
{
    [SerializeField] float scaleAnimationLength;
    [SerializeField] float moveAnimationLength;
    [SerializeField] LeanTweenType scaleAnimationType;
    [SerializeField] LeanTweenType moveAnimationType;

    void Start()
    {
        LeanTween.scale(gameObject, Vector3.one, scaleAnimationLength).setEase(scaleAnimationType);
        LeanTween.move(gameObject, Vector3.zero, moveAnimationLength).setEase(moveAnimationType);
    }
}
