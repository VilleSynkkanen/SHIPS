using UnityEngine;

public class ExitWithoutJoining : MonoBehaviour
{
    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Actions.Quit.performed += ctx => GameController.instance.Quit();
    }

    void OnEnable()
    {
        controls.Actions.Enable();
    }
    void OnDisable()
    {
        controls.Actions.Disable();
    }
}
