using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementHazzard : MonoBehaviour
{
    public float speed = 5f;
    public float limitX;
    private ClickPrecision clickPrecision;

    private void Start()
    {

    }

    void Update()
    {     
        transform.Translate(Vector2.right * speed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            clickPrecision.AddScore();
        }
    }

}
