using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderDetector : MonoBehaviour
{
    public GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                
                gameManager.isSliderClicked = true;
                Debug.Log(gameManager.isSliderClicked);
            }
            else
            {
                gameManager.isSliderClicked = false;
                Debug.Log(gameManager.isSliderClicked);
            }
        }
    }
}
