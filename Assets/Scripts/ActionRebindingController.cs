using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionRebindingController : MonoBehaviour
{
    [SerializeField] InputActionAsset actions;
    [SerializeField] InputActionAsset defaultActions;
    [SerializeField] ActionRebindingUI ui;

    void Start()
    {
        //LoadKeybinds();
        ui.UpdateUIElements();
    }

    public void Rebind(string actionAndGroup)
    {
        //arr[0] = action name, arr[1] = group
        string[] arr = actionAndGroup.Split(':');
        string mapName;
        if (arr.Length <= 2)
            mapName = "Actions";
        else
            mapName = arr[2];
        InputActionMap map = actions.FindActionMap(mapName);
        InputAction action = map.FindAction(arr[0]);
        RebindActionStart(action, arr[1]);
    }

    public void RebindActionStart(InputAction inputAction, string group)
    {
        print("started");
        InputActionRebindingExtensions.RebindingOperation rebindOperation = null;
        
        void CleanUp()
        {
            rebindOperation?.Dispose();
            rebindOperation = null;
        }

        int bindingIndex = inputAction.GetBindingIndex(InputBinding.MaskByGroup(group));
        string controlType;
        string cancelType;
        bool keyboard;
        if (bindingIndex == 3)
        {
            controlType = "<Gamepad>";
            cancelType = "<Gamepad>/start";
            keyboard = false;
        }
        else
        {
            controlType = "<keyboard>";
            cancelType = "<Keyboard>/escape";
            keyboard = true;
        }

        rebindOperation = inputAction.PerformInteractiveRebinding(bindingIndex).WithCancelingThrough(cancelType)
            .WithControlsHavingToMatchPath(controlType).OnCancel(operation =>
            {
                CleanUp();
                print("canceled");
                ui.SetInstructionOverlay(false);
            })
            .OnComplete(operation =>
            {
                CleanUp();
                print("complete");
                ui.UpdateSingleElement(inputAction, bindingIndex, inputAction.actionMap.name);
                ui.SetInstructionOverlay(false);
            });

        ui.SetInstructionOverlay(true, keyboard);
        rebindOperation.Start();
    }

    public void SaveKeybinds()
    {
        //does not save input mappings
        //traverse through bindings and save to a different class and save that to json
        //loading similarly

        //or find a way to make it work with current system
        string json = actions.ToJson();
        //Debug.Log("Saving as JSON: " + json);
        File.WriteAllText(Application.persistentDataPath + "/keybinds.txt", json);
    }

    public void LoadKeybinds()
    {
        // loading seems to work
        if(File.Exists(Application.persistentDataPath + "/keybinds.txt"))
        {
            //print("exists");
            string savedKeybinds = File.ReadAllText(Application.persistentDataPath + "/keybinds.txt");
            //Debug.Log("Loaded JSON: " + savedKeybinds);
            actions.LoadFromJson(savedKeybinds);
            ui.UpdateUIElements();
        }
        else
        {
            ResetToDefault();
        }
    }

    public void ResetToDefault()
    {
        string json = defaultActions.ToJson();
        //Debug.Log("Saving as JSON: " + json);
        File.WriteAllText(Application.persistentDataPath + "/keybinds.txt", json);
        LoadKeybinds();
        ui.UpdateUIElements();
    }
}
