using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickPrecision : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject hazzardPrefab;
    public TextMeshProUGUI scoreText;
    public PanelManager panelManager;
    public float timer;
    public int score;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        scoreText.text = score.ToString();
        if (timer > 5)
        {
            Instantiate(hazzardPrefab, spawnPoint.position, spawnPoint.rotation);

            GameManager.Instance.IncreaseScore(1);
            if (score < 2)
            {
                AddScore();
            }
            else
            {
                panelManager.win();
            }
            timer = 0;
        }
    }

    public void AddScore()
    {
        score++;
    }
}
