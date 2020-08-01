using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] Transform[] playerSpawns;
    [SerializeField] Transform[] playerSpawns3;
    [SerializeField] GameObject[] playerPrefabs0;
    [SerializeField] GameObject[] playerPrefabs1;
    [SerializeField] GameObject[] playerPrefabs2;
    [SerializeField] GameObject[] playerPrefabs3;

    GameController controller;
    List<GameObject[]> prefabs = new List<GameObject[]>();
    List<PlayerInput> inputs = new List<PlayerInput>();
    
    void Awake()
    {
        controller = GetComponent<GameController>();
        prefabs.Add(playerPrefabs0);
        prefabs.Add(playerPrefabs1);
        prefabs.Add(playerPrefabs2);
        prefabs.Add(playerPrefabs3);
    }

    public void SpawnPlayers(float spawnAnimationTime = 0)
    {
        Transform[] spawns;
        int players = DeviceAssignment.instance.Inputs.Count;
        if (players == 3)
            spawns = playerSpawns3;
        else
            spawns = playerSpawns;

        for (int i = 0; i < players; i++)
        {
            PlayerInput player;       
            if (DeviceAssignment.instance.Inputs[i].devices.Count > 0)
            {
                player = PlayerInput.Instantiate(prefabs[(int)DeviceAssignment.instance.Ships[i]][i], -1, null, -1,
                    DeviceAssignment.instance.Inputs[i].devices[0]);
            }
            else
            {
                //if device is not plr2 keyboard
                player = PlayerInput.Instantiate(prefabs[(int)DeviceAssignment.instance.Ships[i]][i], -1, null, -1, Keyboard.current);
                player.SwitchCurrentControlScheme("KeyboardSecondary");
                foreach(PlayerInput input in inputs)
                {
                    if(input.devices[0] == Keyboard.current)
                    {
                        input.SwitchCurrentControlScheme("KeyboardPrimary");
                    }
                }
            }
            LeanTween.scale(player.gameObject, new Vector3(0.001f, 0.001f, 0.001f), 0);
            LeanTween.scale(player.gameObject, Vector3.one, spawnAnimationTime);

            inputs.Add(player);
            player.transform.position = spawns[i].position;
            player.transform.rotation = spawns[i].rotation;
            controller.AddPlayer(player.gameObject);
        }
    }

    public void ResetPlayerPositions(List<GameObject> players)
    {
        Transform[] spawns;
        if (players.Count == 3)
            spawns = playerSpawns3;
        else
            spawns = playerSpawns;
        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = spawns[i].position;
            players[i].transform.rotation = spawns[i].rotation;
            players[i].GetComponent<AimControl>().ResetRotations();
        }
    }
}