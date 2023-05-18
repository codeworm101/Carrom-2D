using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;
    public static float score1 = 0;
    public static float score2 = 0;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        score1 = 0;
        score2 = 0;
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isPlayer1Turn)
        {
            scoreText1.text = ": " + score1.ToString();
           // player1Score = score1;
        }
        else
        {
            scoreText2.text = ": " + score2.ToString();
           // player2Score = score2;
        }
    }
}
