using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Winner : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if(gameManager.winner == 1)
        {
            winnerText.text = "Player 1 Wins!";
        }
        else if(gameManager.winner == 2)
        {
            winnerText.text = "Player 2 Wins!";
        }
        else if(gameManager.winner == 3)
        {
            winnerText.text = "Its a Tie!";
        }
    }

    // Update is called once per frame
    /* void Update()
    {
        if(gameManager.winner == 1)
        {
            Debug.Log("Player 1 Wins!");
        }
        else if(gameManager.winner == 2)
        {
            Debug.Log("Player 2 Wins!");
        }
    } */
}
