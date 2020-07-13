using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class ActionRebindingUI : MonoBehaviour
{
    // tmprougui and actionnames lists correspond to each other
    [SerializeField] TextMeshProUGUI[] keyboard;
    [SerializeField] TextMeshProUGUI[] keyboardPrimary;
    [SerializeField] TextMeshProUGUI[] keyboardSecondary;
    [SerializeField] TextMeshProUGUI[] gamepad;
    [SerializeField] InputActionAsset inputs;
    [SerializeField] string[] actionNames;
    [SerializeField] string[] groupNames;

    List<TextMeshProUGUI[]> texts = new List<TextMeshProUGUI[]>();

    private void Awake()
    {
        texts.Add(keyboard);
        texts.Add(keyboardPrimary);
        texts.Add(keyboardSecondary);
        texts.Add(gamepad);
    }

    public void UpdateUIElements()
    {
        InputActionMap map = inputs.FindActionMap("Actions");
        for (int j = 0; j < groupNames.Length; j++)
        {
            for (int i = 0; i < actionNames.Length; i++)
            {
                InputAction action = map.FindAction(actionNames[i]);

                int bindingIndex = action.GetBindingIndex(InputBinding.MaskByGroup(groupNames[j]));
                texts[j][i].text = action.GetBindingDisplayString(bindingIndex);
            }
        }
    }

    public void UpdateSingleElement(InputAction action, int bindingIndex)
    {
        InputActionMap map = inputs.FindActionMap("Actions");

        for (int i = 0; i < actionNames.Length; i++)
        {
            if (action == map.FindAction(actionNames[i]))
                texts[bindingIndex][i].text = action.GetBindingDisplayString(bindingIndex);
        }
   
    }
}
