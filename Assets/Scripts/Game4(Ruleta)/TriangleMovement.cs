using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TriangleMovement : MonoBehaviour
{
    public float speed;
    public float force = 10f;
    

    public bool isActive;


    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {
        if (isActive)
        {
            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);


        }
    }
    
}
