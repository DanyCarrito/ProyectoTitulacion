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


            

            if(score > 3 )
            {
                panelManager.win();
            }
            timer = 0;
    
    }

    public void AddScore()
    {
        Instantiate(hazzardPrefab, spawnPoint.position, spawnPoint.rotation);
        score++;
        GameManager.Instance.IncreaseScore(1);
    }
}
