using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerController : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] 
    Slider StrikerSlider;

    [SerializeField]
    Transform StrikerBG;

    RaycastHit2D hit;

    Rigidbody2D rb;

    [SerializeField]
    Transform ForcePoint;

    bool StrikerForce;
    // Start is called before the first frame update
    void OnEnable()
    {
        StrikerSlider.onValueChanged.AddListener(StrikerXPos);
        gameManager = FindObjectOfType<GameManager>();
        gameManager.playerdone = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

            if(hit.collider)
            {
                if (hit.transform.name == "Striker")
                {
                    StrikerForce = true;
                }


                if (StrikerForce)
                {
                    StrikerBG.LookAt(hit.point);
                }
                float ScaleValue = Vector2.Distance(transform.position, hit.point);

                StrikerBG.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);

                Debug.Log(hit.transform.name);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            rb.AddForce(new Vector3(ForcePoint.position.x - transform.position.x, ForcePoint.position.y - transform.position.y, 0) * 50, ForceMode2D.Impulse);

            StrikerForce = false;

            StrikerBG.localScale = Vector3.zero;

            gameManager.playerdone = true;

        }
    }

    public void StrikerXPos(float Value)
    {
        transform.position = new Vector3(Value, -2.2f,0);
    }
}
