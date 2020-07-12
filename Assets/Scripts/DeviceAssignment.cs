using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class DeviceAssignment : MonoBehaviour
{
    public static DeviceAssignment instance = null;
    public static UnityAction CountdownStart = delegate { };

    [SerializeField] PlayerVictories victories;

    PlayerSpawner spawner;
    InputDevice[] devices;
    List<PlayerInput> inputs = new List<PlayerInput>();
    List<DeviceAssignmentControls> assignments = new List<DeviceAssignmentControls>();
    List<ShipType> ships = new List<ShipType>();

    public List<PlayerInput> Inputs { get => inputs; }
    public List<DeviceAssignmentControls> Assignments { get => assignments; }
    public List<ShipType> Ships { get => ships; }
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        PlayerInputManager.instance.onPlayerJoined += JoinDevice;
        victories.playerVictories = new int[0];
    }

    private void Start()
    {
        spawner = FindObjectOfType<PlayerSpawner>();    
    }

    public void JoinDevice(PlayerInput input)
    {
        Inputs.Add(input);
        DeviceAssignmentControls ass = input.GetComponent<DeviceAssignmentControls>();
        Assignments.Add(ass);
        if(ass != null)
            ass.SetDeviceAssignment(this, Inputs.Count - 1);
    }

    public void CheckReadiness()
    {
        if(Assignments.Count >= 2)
        {
            for (int i = 0; i < Assignments.Count; i++)
            {
                if (!Assignments[i].ready)
                    return;
            }

            StartCoroutine(SpawnShips());
        }
    }

    IEnumerator SpawnShips()
    {
        yield return new WaitForSeconds(0.1f);
        
        if(victories.playerVictories.Length == 0)
        {
            victories.playerVictories = new int[Assignments.Count];
        }
        for (int i = 0; i < Assignments.Count; i++)
        {
            ships.Add((ShipType)assignments[i].Selection.i);
        }
        
        // spawning must be done before deactivating gameobjects
        spawner.SpawnPlayers();
        foreach (DeviceAssignmentControls ass in Assignments)
        {
            if (ass != null)
                ass.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        CountdownStart();
    }

    public void RemoveDevice(DeviceAssignmentControls controls)
    {
        assignments.Remove(controls);
        inputs.Remove(controls.Input);
        if(controls.Input.devices.Count == 0)
        {
            controls.Player2Disconnected();
        }
        Destroy(controls.gameObject);
    }

    void OnDestroy()
    {
        if(PlayerInputManager.instance != null)
            PlayerInputManager.instance.onPlayerJoined -= JoinDevice;
    }
}
