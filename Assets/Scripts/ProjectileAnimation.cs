using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float animationStart;

    private void Start()
    {
        StartCoroutine(ActivateAnimation());
    }

    IEnumerator ActivateAnimation()
    {
        yield return new WaitForSeconds(animationStart);
        anim.enabled = true;
    }
}
