using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameManager.isPlayer1Turn)
        {
                if(collision.gameObject.name == "white")
            {
                Destroy(collision.gameObject);
                ScoreManager.score1 += 1;
            }

            if(collision.gameObject.name == "black")
            {
                Destroy(collision.gameObject);
                ScoreManager.score1 += 1;
            }

            if(collision.gameObject.name == "Queen")
            {
                Destroy(collision.gameObject);
                ScoreManager.score1 += 2;
            }
        }
        else
        {
            if(collision.gameObject.name == "white")
            {
                Destroy(collision.gameObject);
                ScoreManager.score2 += 1;
            }

            if(collision.gameObject.name == "black")
            {
                Destroy(collision.gameObject);
                ScoreManager.score2 += 1;
            }

            if(collision.gameObject.name == "Queen")
            {
                Destroy(collision.gameObject);
                ScoreManager.score2 += 2;
            }
        }
    }
}
