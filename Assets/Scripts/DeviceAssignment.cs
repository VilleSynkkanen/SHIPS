using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DeviceAssignment : MonoBehaviour
{
    public static DeviceAssignment instance = null;
    public static UnityAction CountdownStart = delegate { };
    public static UnityAction VictoriesSetup = delegate { };
    
    [SerializeField] PlayerVictories victories;
    [SerializeField] float spawnAnimationTime;

    PlayerSpawner spawner;
    List<PlayerInput> inputs = new List<PlayerInput>();
    List<DeviceAssignmentControls> assignments = new List<DeviceAssignmentControls>();
    List<ShipType> ships = new List<ShipType>();

    public List<PlayerInput> Inputs { get => inputs; }
    public List<DeviceAssignmentControls> Assignments { get => assignments; }
    public List<ShipType> Ships { get => ships; }
    public bool plr2Joined { get; set; }
    public DeviceAssignmentControls plr2 { get; set; }

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
        plr2Joined = false;
    }

    private void Start()
    {
        spawner = FindObjectOfType<PlayerSpawner>();    
    }

    public void JoinDevice(PlayerInput input)
    {
        DeviceAssignmentControls ass = input.GetComponent<DeviceAssignmentControls>();
        if(ass != null)
        {
            Inputs.Add(input);
            Assignments.Add(ass);
            ass.SetDeviceAssignment(this, Inputs.Count - 1);
        }    
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

        if (Assignments.Count < 2)
        {
            yield break;
        }

        if (victories.playerVictories.Length == 0)
        {
            victories.playerVictories = new int[Assignments.Count];
            VictoriesSetup();
        }
        for (int i = 0; i < Assignments.Count; i++)
        {
            ships.Add((ShipType)assignments[i].Selection.i);
            LeanTween.scale(assignments[i].Selection.ShipImages[assignments[i].Selection.i], Vector3.zero, spawnAnimationTime);
        }

        yield return new WaitForSeconds(spawnAnimationTime);
        
        // spawning must be done before deactivating gameobjects
        spawner.SpawnPlayers(spawnAnimationTime);
        for (int i = 0; i < Assignments.Count; i++)
        {
            assignments[i].Selection.UnjoinAnimation(i);
            Assignments[i].gameObject.SetActive(false);
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

        for(int i = 0; i < assignments.Count; i++)
        {
            assignments[i].SetIndex(i);
            assignments[i].Selection.CheckUIPosition(i);
        }
    }

    void OnDestroy()
    {
        if(PlayerInputManager.instance != null)
            PlayerInputManager.instance.onPlayerJoined -= JoinDevice;
    }
}
