using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public float timer;
    public float timeMax;
    public float score;
    public float spawnRangeX = 10f; 
    public float spawnRangeY = 4.5f;
    public GameObject objectToSpawn;
    public GameObject victoryPanel;
    public Vector3 newScale = new Vector3(2.0f, 2.0f, 1.0f);

    private bool clickIsPressed = false;
    private Vector3 originalScale;
    private PanelManager panelManager;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        //scoreText.text = score.ToString();
        if (Input.GetMouseButtonDown(0) && clickIsPressed)
        {
            score++;

            Destroy(transform.parent.gameObject);
            SpawnObject();
            //GameManager.Instance.IncreaseScore(1);
        }

        if (timer > timeMax)
        {
            timer = 0;
            //victoryPanel.SetActive(true);
            //Time.timeScale = 0f;
            //panelManager.win();
        }
    }

    void SpawnObject()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = newScale;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clickIsPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = originalScale;
            clickIsPressed = false;
        }
    }
}
