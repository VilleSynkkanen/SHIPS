using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerVictories victories;

    bool gameStarted;
    bool countdownStarted;
    [SerializeField] float countdownTime;
    float countdownTimer;
    bool gameEnded;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float startTextDelay;
    [SerializeField] float readyTextDelay;
    [SerializeField] PlayerSpawner spawner;

    List<GameObject> playersAlive = new List<GameObject>();
    List<GameObject> players = new List<GameObject>();
    List<PlayerControlInput> playerInputs = new List<PlayerControlInput>();

    public event UnityAction<int, int[]> gameEnd = delegate { };
    public static event UnityAction GameRestart = delegate { };

    BattleUIManager uiManager;

    public PlayerVictories Victories { get => victories; }

    void Awake()
    {
        Cursor.visible = false;
        
        ShipDamage.destroyed += RemovePlayer;
        gameStarted = false;
        countdownStarted = false;
        gameEnded = false;

        uiManager = GetComponent<BattleUIManager>();
        gameEnd += uiManager.ShowVictoryUi;
        DeviceAssignment.CountdownStart += AllPlayersReady;
    }

    void Update()
    {
        if (!gameStarted && countdownStarted)
            Countdown();
    }

    void Countdown()
    {
        countdownTimer -= Time.deltaTime;
        countdownText.text = (Mathf.Ceil(countdownTimer)).ToString();
        if (countdownTimer <= 0)
            StartGame();
    }

    void AllPlayersReady()
    {
        StartCoroutine(StartCountdown());
    }
    
    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(readyTextDelay);

        countdownStarted = true;
        countdownTimer = countdownTime;
    }

    void StartGame()
    {
        gameStarted = true;
        countdownStarted = false;
        countdownText.text = "GO";

        foreach(GameObject player in playersAlive)
        {
            player.GetComponent<PlayerComponents>().Activate();
        }

        StartCoroutine(HideCountdownText());
    }

    IEnumerator HideCountdownText()
    {
        yield return new WaitForSeconds(startTextDelay);
        countdownText.text = "";
    }
    
    public void AddPlayer(GameObject player)
    {
        playersAlive.Add(player);
        players.Add(player);
        playerInputs.Add(player.GetComponent<PlayerControlInput>());
    }

    public void RemovePlayer(GameObject player)
    {
        playersAlive.Remove(player);
        DisablePlayerControls(player);
        CheckGameEnd();
    }

    void CheckGameEnd()
    {
        if(playersAlive.Count == 1)
        {
            string i = "" + playersAlive[0].tag[1];
            Victory(int.Parse(i) - 1);
        }
        else if(playersAlive.Count == 0)
        {
            Draw();
        }
    }
    
    void DisablePlayerControls(GameObject player)
    {
        PlayerComponents components = player.GetComponent<PlayerComponents>();
        components.Deactivate();
        components.movement.SetControlsToZero();
    }
    
    void Victory(int i)
    {
        if(!gameEnded)
        {
            DisablePlayerControls(playersAlive[0]);
            victories.playerVictories[i]++;
            gameEnd(i, victories.playerVictories);
            Cursor.visible = true;
            gameEnded = true;
        }
    }
    
    void Draw()
    {
        if (!gameEnded)
        {
            gameEnd(-1, victories.playerVictories);
            Cursor.visible = true;
            gameEnded = true;
        } 
    }

    public void Restart()
    {
        gameStarted = false;
        countdownStarted = false;
        gameEnded = false;
        Cursor.visible = false;
        spawner.ResetPlayerPositions(players);
        playersAlive = new List<GameObject>();
        uiManager.HideVictoryUI(); 
        ProjectileParent.instance.DestroyAllProjectiles();
        GameRestart();
        foreach(GameObject player in players)
        {
            playersAlive.Add(player);
            
        }
        AllPlayersReady();
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void OnDestroy()
    {
        ShipDamage.destroyed -= RemovePlayer;
        gameEnd -= uiManager.ShowVictoryUi;
        DeviceAssignment.CountdownStart -= AllPlayersReady;
    }
}