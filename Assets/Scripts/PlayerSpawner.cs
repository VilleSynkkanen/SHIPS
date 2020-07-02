using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] Transform[] playerSpawns;
    [SerializeField] Transform[] playerSpawns3;
    [SerializeField] GameObject[] playerPrefabs;
    [SerializeField] PlayerVictories victories;

    GameController controller;
    
    void Awake()
    {
        controller = GetComponent<GameController>();
        SpawnPlayers();
    }

    public void SpawnPlayers()
    {
        Transform[] spawns;
        int players = victories.playerVictories.Length;
        if (players == 3)
            spawns = playerSpawns3;
        else
            spawns = playerSpawns;

        for (int i = 0; i < players; i++)
        {
            GameObject player = Instantiate(playerPrefabs[i], spawns[i].position, spawns[i].rotation);
            controller.AddPlayer(player);
        }
    }
}