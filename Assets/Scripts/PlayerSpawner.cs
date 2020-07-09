﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] Transform[] playerSpawns;
    [SerializeField] Transform[] playerSpawns3;
    [SerializeField] GameObject[] playerPrefabs0;
    [SerializeField] GameObject[] playerPrefabs1;
    [SerializeField] GameObject[] playerPrefabs2;

    GameController controller;

    List<GameObject[]> prefabs = new List<GameObject[]>();
    
    void Awake()
    {
        controller = GetComponent<GameController>();

        prefabs.Add(playerPrefabs0);
        prefabs.Add(playerPrefabs1);
        prefabs.Add(playerPrefabs2);
    }

    public void SpawnPlayers()
    {
        Transform[] spawns;
        int players = DeviceAssignment.instance.Inputs.Count;
        if (players == 3)
            spawns = playerSpawns3;
        else
            spawns = playerSpawns;

        for (int i = 0; i < players; i++)
        {
            print(players);
            print(DeviceAssignment.instance.Inputs.Count);
            PlayerInput player = PlayerInput.Instantiate(prefabs[(int)DeviceAssignment.instance.Ships[i]][i], -1, null, -1, 
               DeviceAssignment.instance.Inputs[i].devices[0]);
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
        }
    }
}