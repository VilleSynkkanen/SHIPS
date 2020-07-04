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
    PlayerSpawner spawner;

    List<PlayerInput> inputs = new List<PlayerInput>();
    List<DeviceAssignmentControls> assignments = new List<DeviceAssignmentControls>();
    List<ShipType> ships = new List<ShipType>();
    InputDevice[] devices;
    [SerializeField] PlayerVictories victories;

    public List<PlayerInput> Inputs { get => inputs; }
    public List<DeviceAssignmentControls> Assignments { get => assignments; }
    public List<ShipType> Ships { get => ships; }
    public static UnityAction CountdownStart;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        PlayerInputManager.instance.onPlayerJoined += JoinDevice;
        PlayerInputManager.instance.onPlayerLeft += RemoveDevice;
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

            print("all ready");
            Invoke("SpawnShips", 1);
            //SpawnShips();
        }
    }

    void SpawnShips()
    {
        if(victories.playerVictories.Length == 0)
        {
            victories.playerVictories = new int[Assignments.Count];
        }
        for (int i = 0; i < Assignments.Count; i++)
        {
            ships.Add((ShipType)assignments[i].Selection.i);
        }
        spawner.SpawnPlayers();
        foreach (DeviceAssignmentControls ass in Assignments)
        {
            if (ass != null)
                ass.gameObject.SetActive(false);
        }

        CountdownStart();
    }

    public void RemoveDevice(PlayerInput input)
    {
        // implement
    }
}
