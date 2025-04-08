using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction = Vector2.down;
    public Vector2 upLimit = new Vector2(0f, 2.2f);
    public Vector2 downLimit = new Vector2(0f, -4f);


    void Update()
    {
        if (PanelManager.Instance.isTutorialOver)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            Debug.Log("y position :" + transform.position.y);

            if (transform.position.y >= upLimit.y)
            {
                direction = Vector2.down;
            }

            if (transform.position.y <= downLimit.y)
            {
                Debug.Log("Va parribe");
                direction = Vector2.up;
            }
        }
    }
}
