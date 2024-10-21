using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TriangleMovement : MonoBehaviour
{
    public float speed;
    public float force = 10f;
    public float timeToRespawn;
    public Vector2 spawnPosition;

    private float timer;
    private Rigidbody2D rb;
    public ObjectPool objectPool;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);

            if (timer < timeToRespawn)
            {
                timer = 0;
                GameObject pooledObject = objectPool.GetPooledObject();

                if (pooledObject != null)
                {
                    pooledObject.transform.position = spawnPosition;
                    pooledObject.SetActive(true); 
                }
            }
        }
    }
}
