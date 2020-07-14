﻿using System.Collections;
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
    [SerializeField] int mapSwitchIndex;

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
        InputActionMap map;
        InputActionMap mapActions = inputs.FindActionMap("Actions");
        InputActionMap mapMenu = inputs.FindActionMap("MainMenu");
        for (int j = 0; j < groupNames.Length; j++)
        {
            for (int i = 0; i < actionNames.Length; i++)
            {
                if(texts[j].Length > i)
                {
                    print(texts[j].Length + " " + i);
                    if (i < mapSwitchIndex)
                        map = mapActions;
                    else
                        map = mapMenu;
                    InputAction action = map.FindAction(actionNames[i]);
                    int bindingIndex = action.GetBindingIndex(InputBinding.MaskByGroup(groupNames[j]));
                    texts[j][i].text = action.GetBindingDisplayString(bindingIndex);
                }
            }
        }
    }

    public void UpdateSingleElement(InputAction action, int bindingIndex, string actionMap)
    {
        InputActionMap map = inputs.FindActionMap(actionMap);

        for (int i = 0; i < actionNames.Length; i++)
        {
            if (action == map.FindAction(actionNames[i]))
                texts[bindingIndex][i].text = action.GetBindingDisplayString(bindingIndex);
        }
   
    }
}