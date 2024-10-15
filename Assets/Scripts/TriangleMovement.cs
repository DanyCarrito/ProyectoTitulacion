using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    public float speed;
    public float force = 10f;

    private float timerRespawn;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        timerRespawn += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            //if(timerRespawn <)
        }
    } 
}
