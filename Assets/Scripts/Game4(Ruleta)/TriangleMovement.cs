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

    private Rigidbody2D rb;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        }
    }

}
