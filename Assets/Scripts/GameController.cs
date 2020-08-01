using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerVictories victories;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] PlayerSpawner spawner;
    [SerializeField] float countdownTime;
    [SerializeField] float startTextDelay;
    [SerializeField] float readyTextDelay;
    [SerializeField] float restartExtraDelay;
    [SerializeField] float shipScalingDelay;
    [SerializeField] float shipScalingTime;
    [SerializeField] float shipScalingInterval;

    BattleUIManager uiManager;
    List<GameObject> playersAlive = new List<GameObject>();
    List<GameObject> players = new List<GameObject>();
    List<PlayerControlInput> playerInputs = new List<PlayerControlInput>();

    float countdownTimer;
    bool gameEnded;
    bool gameStarted;
    bool countdownStarted;
    bool firstStart;

    public PlayerVictories Victories { get => victories; }

    public event UnityAction<int, int[]> gameEnd = delegate { };
    public static event UnityAction GameRestart = delegate { };

    void Awake()
    {
        Cursor.visible = false;
        
        ShipDamage.destroyed += RemovePlayer;
        gameStarted = false;
        countdownStarted = false;
        gameEnded = false;
        firstStart = true;

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
        float delay = readyTextDelay;
        if (!firstStart)
            delay += restartExtraDelay;
        yield return new WaitForSeconds(delay);

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
            gameEnded = true;
        }
    }
    
    void Draw()
    {
        if (!gameEnded)
        {
            gameEnd(-1, victories.playerVictories);
            gameEnded = true;
        } 
    }

    public void Restart()
    {
        firstStart = false;
        gameStarted = false;
        countdownStarted = false;
        gameEnded = false;
        StartCoroutine(RestartCycle());
    }

    public void ShipSelection()
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
        DeviceAssignment.CountdownStart -= AllPlayersReady;
    }

    IEnumerator RestartCycle()
    {
        Vector3 scalingGoal = new Vector3(0.001f, 0.001f, 0.001f);
        uiManager.HideVictoryUI();
        yield return new WaitForSeconds(shipScalingDelay);

        foreach (GameObject player in players)
        {
            LeanTween.scale(player, scalingGoal, shipScalingTime);
        }

        ProjectileParent.instance.DestroyAllProjectiles();
        yield return new WaitForSeconds(shipScalingInterval);
        
        spawner.ResetPlayerPositions(players);
        playersAlive = new List<GameObject>();
        GameRestart();
        foreach (GameObject player in players)
        {
            playersAlive.Add(player);
            LeanTween.scale(player, Vector3.one, shipScalingTime);

        }
        AllPlayersReady();
    }
}