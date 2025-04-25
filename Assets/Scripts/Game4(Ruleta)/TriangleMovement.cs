using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class TriangleMovement : MonoBehaviour
{
    public float speed;
    public float force = 10f;
    public int score;
    public bool isActive;
    public static TriangleMovement Instance { get; private set; }
    public bool touchingR = false;
    private Rigidbody2D rb;
    private ObjectPool objectPool;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        objectPool = GameObject.FindObjectOfType<ObjectPool>();
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);


        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Roulette"))
        {
            score++;
            GameManager.Instance.IncreaseScore(1);
            touchingR = true;
        }

        if (collision.gameObject.CompareTag("Triangle") && !touchingR)
        {

            GameManager.Instance.IncreaseScore(-1);
            objectPool.RemovePooledObject(this.gameObject);
            Destroy(gameObject);
        }
    }

    public void ConvertKinematic()
    {
        rb.isKinematic = true;
    }

}
