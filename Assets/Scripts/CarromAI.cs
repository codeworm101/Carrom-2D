using System.Collections;
using UnityEngine;


public class CarromAI : MonoBehaviour
{
    public float moveDelay = 1f;  // Delay between AI moves

    public GameManager gameManager;
    public bool isMyTurn;
    private float currentDelay;
    Rigidbody2D rb;

    public void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        isMyTurn = true;
        currentDelay = 0f;
        rb = GetComponent<Rigidbody2D>();
        gameManager.enemydone = false;
    }

    public void Update()
    {
        if (!isMyTurn)
        {
            StartCoroutine(WaitForTurnToFinish());
            return;
        }

        currentDelay += Time.deltaTime;

        if (currentDelay >= moveDelay)
        {
            MakeAIMove();
            currentDelay = 0f;
            isMyTurn = false;
        }
    }

    /* public void StartTurn()
    {
        isMyTurn = true;
    } */

    public void MakeAIMove()
    {
        // Implement your AI logic here to make a move on the carrom board
        // You can access the carrom board and other necessary game objects through the gameManager reference

        // Example: Randomly select a pocket and a coin to shoot
        int pocketIndex = Random.Range(0, gameManager.pockets.Count);
        int coinIndex = Random.Range(0, gameManager.coins.Count);
        Debug.Log(gameManager.coinPositions[coinIndex].x);
        Debug.Log(gameManager.coinPositions[coinIndex].y);
        //Vector2 direction = gameManager.coinPositions[coinIndex].position - transform.position; 
        rb.AddForce(new Vector3(gameManager.coinPositions[coinIndex].x - transform.position.x, gameManager.coinPositions[coinIndex].y - transform.position.y, 0)*100);
        //rb.AddForce(direction * 1000, ForceMode2D.Impulse);


        // Shoot the selected coin towards the selected pocket
       // gameManager.ShootCoin(gameManager.coinPositions[coinIndex], gameManager.pocketPositions[pocketIndex]);
    }

    public IEnumerator WaitForTurnToFinish()
    {
        yield return new WaitForSeconds(4f);
        gameManager.enemydone = true;
    }


}
