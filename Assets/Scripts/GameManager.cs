using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool aremoving = true;
    bool isdone;

    [SerializeField]
    Slider strikerSlider;
    float timer = 120.0f;
    public TMP_Text timerText;

    public GameObject player1;
    public GameObject player2;
    public List<GameObject> pockets; // List of pocket game objects
    public List<GameObject> coins; // List of coin game objects

    public Vector3[] pocketPositions; // Array to store pocket positions
    public Vector3[] coinPositions; // Array to store coin positions

    public static float player1Score;
    public static float player2Score;
    
    public bool isPlayer1Turn = true;
    private bool isTurnInProgress = false;
    public int winner;
    public bool enemydone = false;
    public bool playerdone = false;

    //public CarromAI script;
    //public StrikerController slider;

    public void Start()
    {
       DontDestroyOnLoad(transform.gameObject);
       // carromAI = GameObject.FindObjectOfType<CarromAI>();
        // Initialize the pocketPositions and coinPositions arrays with the same size as the pockets and coins arrays
        pocketPositions = new Vector3[pockets.Count];
        coinPositions = new Vector3[coins.Count];

        // Store the initial positions of the pocket game objects
        for (int i = 0; i < pockets.Count; i++)
        {
            pocketPositions[i] = pockets[i].transform.position;
        }

        // Store the initial positions of the coin game objects
        for (int i = 0; i < coins.Count; i++)
        {
            coinPositions[i] = coins[i].transform.position;
        }
        // Activate the first player and deactivate the second player
        player1.SetActive(true);
        player2.SetActive(false);
    }

    public void Update()
    {
        StartCoroutine(RemoveCells());

        foreach (GameObject Coin in coins)
           {
            if (Coin.GetComponent<Rigidbody2D>() == null)
                {
                    continue;
                }
            if (Coin.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
                {
                    aremoving = true;
                    isTurnInProgress = true;
                }
            else
                {
                    aremoving = false;
                    isTurnInProgress = false;
                }
            }

        if(coins.Count==0)
        {
            if(player1Score>player2Score)
            {
                SceneManager.LoadScene("GameOver");
                winner = 1;

            }
            else if(player1Score<player2Score)
            {
                SceneManager.LoadScene("GameOver");
                winner = 2;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
                winner = 3;
            }

        }
        //List<GameObject> coins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Coin"));
        if(timer>0)
        {
            timer -= Time.deltaTime;
        }
        double minutes = Mathf.Floor(timer / 60);
        double seconds = Mathf.RoundToInt(timer % 60);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        if(timer<=0)
        {
            SceneManager.LoadScene("GameOver");
        }

        // Update the positions of the coin game objects
        for (int i = 0; i < coins.Count; i++)
        {
            coinPositions[i] = coins[i].transform.position;
        }
        // Check if a turn is in progress
            // Check if the player has pressed the space bar
        if(Input.GetMouseButtonUp(0))
        {
            StartCoroutine(WaitForTurnToFinish());
        }

        if(enemydone)
        {
            StartCoroutine(SwitchPlayers());
        }

        enemydone = false;
        player1Score = ScoreManager.score1;
        player2Score = ScoreManager.score2;
    }

    public System.Collections.IEnumerator SwitchPlayers()
    {
        CarromAI carromAI = GetComponent<CarromAI>();
        isTurnInProgress = true;

        // Deactivate the current player
        if (isPlayer1Turn)
            player1.SetActive(false);
        else
            player2.SetActive(false);

        // Wait for a short duration to indicate the transition
        yield return new WaitForSeconds(0.5f);

        // Switch turns between players
        isPlayer1Turn = !isPlayer1Turn;

        // Activate the next player
        if (isPlayer1Turn)
        {
            player1.transform.position = new Vector3(0, -2.2f, 0);
            strikerSlider.value = 0;
            player1.SetActive(true);
        }
        else
        {
            player2.transform.position = new Vector3(0, 2.2f, 0);
            player2.SetActive(true);
        }
        // Reset turn in progress flag
        isTurnInProgress = false;
    }

    public IEnumerator WaitForTurnToFinish()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log(aremoving);
        yield return new WaitUntil(() => aremoving == false);
        StartCoroutine(SwitchPlayers());
    }   

    public IEnumerator RemoveCells()
    {
        yield return 0;
 
        coins.RemoveAll(item => item == null);
 
    }
}    


