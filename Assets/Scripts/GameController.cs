using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    MusicPlayer musicPlayer;

    [SerializeField] PlayerVictories victories;

    [SerializeField] GameObject[] playersReadyTexts;
    [SerializeField] GameObject instructionText;
    bool gameStarted;
    bool countdownStarted;
    [SerializeField] float countdownTime;
    float countdownTimer;
    bool gameEnded;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float startTextDelay;
    [SerializeField] float readyTextDelay;

    List<GameObject> players = new List<GameObject>();
    List<PlayerControlInput> playerInputs = new List<PlayerControlInput>();
    List<bool> playersReady = new List<bool>();

    public event UnityAction<int, int[]> gameEnd = delegate { };

    BattleUIManager uiManager;

    public PlayerVictories Victories { get => victories; }

    void Awake()
    {
        Cursor.visible = false;
        
        ShipDamage.destroyed += RemovePlayer;
        gameStarted = false;
        countdownStarted = false;
        gameEnded = false;

        musicPlayer = FindObjectOfType<MusicPlayer>();
        uiManager = GetComponent<BattleUIManager>();
        gameEnd += uiManager.ShowVictoryUi;
    }

    void Update()
    {
        if (!countdownStarted && !gameStarted)
            ReadReadyInput();
        if (!gameStarted && countdownStarted)
            Countdown();
    }

    void ReadReadyInput()
    {
        bool allReady = true;
        for (int i = 0; i < players.Count; i++)
        {
            if (playerInputs[i].vertical > 0)
            {
                playersReady[i] = true;
                playersReadyTexts[i].SetActive(true);
            }

            if (!playersReady[i])
            {
                allReady = false;
            }
        }

        if (allReady)
        {
            StartCoroutine(StartCountdown());
        }
    }

    void Countdown()
    {
        countdownTimer -= Time.deltaTime;
        countdownText.text = (Mathf.Ceil(countdownTimer)).ToString();
        if (countdownTimer <= 0)
            StartGame();
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(readyTextDelay);

        countdownStarted = true;
        countdownTimer = countdownTime;
        instructionText.SetActive(false);
    }

    void StartGame()
    {
        gameStarted = true;
        countdownStarted = false;
        countdownText.text = "GO";

        foreach(GameObject player in players)
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
        players.Add(player);
        playerInputs.Add(player.GetComponent<PlayerControlInput>());
        playersReady.Add(false);
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
        }
        else if(players.Count == 0)
        {
            Draw();
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
        if(!gameEnded)
        {
            DisablePlayerControls(players[0]);
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