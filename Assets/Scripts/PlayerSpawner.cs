using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] Transform[] playerSpawns;
    [SerializeField] GameObject[] playerPrefabs;

    GameController controller;
    
    void Awake()
    {
        controller = GetComponent<GameController>();
        SpawnPlayers();
    }

    public void SpawnPlayers()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("players", 2); i++)
        {
            GameObject player = Instantiate(playerPrefabs[i], playerSpawns[i].position, playerSpawns[i].rotation);
            controller.AddPlayer(player);
        }
    }
}