using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{
    public GameObject obstacle;

    public Timer timerScpt;

    // Start is called before the first frame update
    void Start()
    {
       // timerScpt = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 myPosition = transform.position; 
        Vector2 targetPosition = obstacle.transform.position; 

        float myRadius = GetComponent<CircleCollider2D>().radius * transform.localScale.x; 

        BoxCollider2D targetBox = obstacle.GetComponent<BoxCollider2D>();

        Vector2 boxSize = targetBox.size * obstacle.transform.localScale; 
        Vector2 boxMin = targetPosition - boxSize / 2; 
        Vector2 boxMax = targetPosition + boxSize / 2; 

        float closestX = Mathf.Clamp(myPosition.x, boxMin.x, boxMax.x);
        float closestY = Mathf.Clamp(myPosition.y, boxMin.y, boxMax.y);


        Vector2 closestPoint = new Vector2(closestX, closestY);

        float distance = Vector2.Distance(myPosition, closestPoint);

        if (distance <= myRadius)
        {
            Debug.Log("Obstaculo");
            timerScpt.TimePenalty();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("muerte");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("ganaste");
            //Time.timeScale = 0f;
            PanelManager.Instance.win();
        }
    }
}
