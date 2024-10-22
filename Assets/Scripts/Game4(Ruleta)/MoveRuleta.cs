using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRuleta : MonoBehaviour
{
    public float rotationSpeed = 50f; 

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
        }
    }
}
