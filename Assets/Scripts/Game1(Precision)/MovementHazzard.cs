using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementHazzard : MonoBehaviour
{
    public float speed = 5f;
    public float limitX;
    public ClickPrecision clickPrecision;

    private void Start()
    {
        //clickPrecision = GameObject.Find("Instantiate").GetComponent<ClickPrecision>();
    }

    void Update()
    {     
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            ClickPrecision.Instance.AddScore();
            GameManager.Instance.IncreaseScore(1);
        }
    }

}
