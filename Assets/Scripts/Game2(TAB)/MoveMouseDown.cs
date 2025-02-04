using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouseDown : MonoBehaviour
{
    public float speed;
    public float verticalStep = 0.5f;
    public Vector3 rightLimit = new Vector3(10f, 0f, 0f); 
    public Vector3 leftLimit = new Vector3(-10f, 0f, 0f); 
    public Vector3 finalPosition = new Vector3(0f, 0f, 0f);

    private Vector3 initialPosition;
    private Vector3 direction = Vector3.right;

    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PanelManager.Instance.isTutorialOver)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            if (transform.position.x >= rightLimit.x)
            {
                direction = Vector3.left;
                MoveDown();
            }

            if (transform.position.x <= leftLimit.x)
            {
                direction = Vector3.right;
                MoveDown();
            }

            if (transform.position.y <= finalPosition.y)
            {
                ResetToInitialPosition();
            }
        }


    }

    void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - verticalStep, transform.position.z);
    }

    void ResetToInitialPosition()
    {
        transform.position = initialPosition;
        direction = Vector3.right; 
    }
}
