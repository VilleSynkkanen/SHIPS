using UnityEngine;

public class WaterAnimationController : MonoBehaviour
{
    [SerializeField] GameObject[] animationObjects;
    
    void Awake()
    {
        SetAnimations();
    }

    public void SetAnimations()
    {
        int active = PlayerPrefs.GetInt("WaterAnimation", 1);
        bool activeBool = true;
        if (active == 0)
            activeBool = false;
        
        foreach(GameObject animation in animationObjects)
        {
            animation.SetActive(activeBool);
        }
    }
}
