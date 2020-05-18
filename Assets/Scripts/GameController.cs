using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    MusicPlayer musicPlayer;

    [SerializeField] PlayerVictories victories;

    bool[] playersReady;
    bool gameEnded;

    List<GameObject> players = new List<GameObject>();

    public event UnityAction<int, int[]> gameEnd = delegate { };

    BattleUIManager uiManager;

    public PlayerVictories Victories { get => victories; }

    void Awake()
    {
        Cursor.visible = false;
        
        ShipDamage.destroyed += RemovePlayer;
        gameEnded = false;

        musicPlayer = FindObjectOfType<MusicPlayer>();
        uiManager = GetComponent<BattleUIManager>();
        gameEnd += uiManager.ShowVictoryUi;
    }

    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }

    public void RemovePlayer(GameObject player)
    {
        players.Remove(player);
        DisablePlayerControls(player);
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
    
    void DisablePlayerControls(GameObject player)
    {
        ShipMovement movement = player.GetComponent<ShipMovement>();
        movement.playerInput.enabled = false;
        movement.SetControlsToZero();
    }
    
    void Victory(int i)
    {
        DisablePlayerControls(players[0]);
        victories.playerVictories[i]++;
        gameEnd(i, victories.playerVictories);
        Cursor.visible = true;
    }

    void Draw()
    {
        gameEnd(-1, victories.playerVictories);
        Cursor.visible = true;
    }

    
    public void Restart()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public void Quit()
    {
        Destroy(musicPlayer.gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    void OnDestroy()
    {
        ShipDamage.destroyed -= RemovePlayer;
        gameEnd -= uiManager.ShowVictoryUi;
    }
}