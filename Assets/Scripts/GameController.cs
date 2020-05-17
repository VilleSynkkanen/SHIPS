using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerVictories victories;

    bool[] playerReady;
    bool gameEnded;

    List<GameObject> players = new List<GameObject>();
    
    GameObject player1;         // required for restart/quit
    PlayerInput player1Input;

    public event UnityAction<int, int[]> gameEnd = delegate { };

    BattleUIManager uiManager;

    public PlayerVictories Victories { get => victories; }

    void Awake()
    {
        ShipDamage.destroyed += RemovePlayer;
        gameEnded = false;

        uiManager = GetComponent<BattleUIManager>();
        gameEnd += uiManager.ShowVictoryUi;
    }

    void Start()
    {
        if (players.Count > 0)
        {
            player1 = players[0];
            player1Input = player1.GetComponent<PlayerInput>();
        }        
    }

    void Update()
    {
        if (gameEnded)
            ReadInput();
    }

    void ReadInput()
    {
        if (player1Input.shootForward)
        {
            Restart();
        }
        if (player1Input.mine)
        {
            Quit();
        }
    }

    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }

    public void RemovePlayer(GameObject player)
    {
        players.Remove(player);
        CheckGameEnd();
    }

    void CheckGameEnd()
    {
        if(players.Count == 1)
        {
            string i = "" + players[0].tag[1];
            Victory(int.Parse(i) - 1);
            gameEnded = true;
        }
        else if(players.Count == 0)
        {
            Draw();
            gameEnded = true;
        }
    }
    
    void Victory(int i)
    {
        victories.playerVictories[i]++;
        gameEnd(i, victories.playerVictories);
        RestorePlayer1();
    }

    void Draw()
    {
        gameEnd(-1, victories.playerVictories);
        RestorePlayer1();
    }

    void RestorePlayer1()
    {
        if (player1 != null)
        {
            player1.SetActive(true);
            player1.transform.position = new Vector3(0, 0, -100);
        }
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void OnDestroy()
    {
        ShipDamage.destroyed -= RemovePlayer;
        gameEnd -= uiManager.ShowVictoryUi;
    }
}