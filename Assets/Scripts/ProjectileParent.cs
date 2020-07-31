using UnityEngine;

public class ProjectileParent : MonoBehaviour
{
    public static ProjectileParent instance = null;
    [SerializeField] float objectScalingTime;

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
            LeanTween.scale(child.gameObject, Vector3.zero, objectScalingTime);
            Destroy(child.gameObject, objectScalingTime);
        }
    }
}
