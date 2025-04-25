using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MoveRuleta : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float rotationSpeed = 50f;

    private void Start()
    {
        //scoreText.text = TriangleMovement.Instance.score.ToString();
    }
    void Update()
    {
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Triangle"))
        {
            collision.transform.SetParent(transform);
            collision.gameObject.GetComponent<TriangleMovement>().isActive = false;
            collision.gameObject.GetComponent<TriangleMovement>().ConvertKinematic();
        }
        //else ()
        //{
        //    //destruir
        //}
    }
}
