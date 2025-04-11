using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using DG.Tweening;
using TMPro;

public class MovementMouse : MonoBehaviour
{
    Camera cam;
    bool isColision;
    public TextMeshProUGUI scoreText;

    public float score;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        int displayScore = Mathf.Max(0, Mathf.FloorToInt(score));
        scoreText.text = displayScore.ToString();

        if (PanelManager.Instance.isTutorialOver)
        {
            transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        }

        Debug.Log(score);
        if(!isColision )
        {
            if( score > 0 )
            {
                score -= 0.01f;
                GameManager.Instance.IncreaseScore(-0.1f);
            }
            else if( score <= 0 ) 
            {
                score = 0;
            }
            
        }
        if( score >= 50 )
        {
            PanelManager.Instance.win();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            Debug.Log("Colisionando");
            isColision = true;
            score += 0.1f;
            GameManager.Instance.IncreaseScore(0.1f);
            GetComponent<SpriteRenderer>().DOColor(Color.green, .25f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            isColision = false;
            Debug.Log("NOOO olisionando");

            Sequence s = DOTween.Sequence();
            //s.Append(Camera.main.DOShakePosition(.25f)).Append(Camera.main.transform.DOMove(new Vector3(0, 0 ,-10), .5f)) ;
            
            GetComponent<SpriteRenderer>().DOColor(Color.red, .25f);
        }
    }

}
