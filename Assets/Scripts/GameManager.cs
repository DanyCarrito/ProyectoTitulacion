using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None, 
    Precision,
    Target,
    TargetMovil
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float timer = 0;
    public int score = 0;

    PanelManager panelManager;

    GameState gameState;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        gameState = GameState.None;
    }

    private void Update()
    {
        if(gameState == GameState.Target)
        {

        }
    }

    public void ChangeGameState(GameState newState)
    {
        gameState = newState;
        switch(gameState)
        {
            case GameState.None:
                break;
            case GameState.Precision:
                Debug.Log("precision");
                break;
            case GameState.Target:
                Debug.Log("target");
                //StartTimer();
                break;
            case GameState.TargetMovil:
                Debug.Log("targetMovil");
                //StartTimer();
                break;
        }
    }

    public void StartTimer()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            //panelManager.GetRandomHardGame();
            timer = 0;
        }
        Debug.Log(timer);
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}
