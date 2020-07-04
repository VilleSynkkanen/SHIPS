using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParent : MonoBehaviour
{
    public static ProjectileParent instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    public void DestroyAllProjectiles()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
