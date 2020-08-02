using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTerrainAnimation : MonoBehaviour
{
    [SerializeField] float animationDelay;
    [SerializeField] float scaleAnimationLength;
    [SerializeField] float moveAnimationLength;
    [SerializeField] LeanTweenType scaleAnimationType;
    [SerializeField] LeanTweenType moveAnimationType;

    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(animationDelay);
        LeanTween.scale(gameObject, Vector3.one, scaleAnimationLength).setEase(scaleAnimationType);
        LeanTween.move(gameObject, Vector3.zero, moveAnimationLength).setEase(moveAnimationType);
    }
}
