using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MovementMouse : MonoBehaviour
{
    Camera cam;
    bool isColision;

    public float score;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            Debug.Log("Colisionando");
            score += 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            isColision = true;
            Debug.Log("NOOO olisionando");
            score--;
        }
    }

}
