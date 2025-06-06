using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PanelManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject tutorialPanel;
    public GameObject pausePanel;
    public GameObject gamePanel;
    public GameObject chooserPanel;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    public TMP_Text scoreText;
    public TMP_Text finalScoreText;

    public float timerTutorial;
    public bool isTutorialOver;
  

    private int randomScene = -1;
    private int[] hardGames = { 2, 3 };

    public static PanelManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.AddLevelTime(0.1f);
        //Time.timeScale = levelSpeed;
        if (tutorialPanel  != null) 
        {
            tutorialPanel.SetActive(true);
        }
        isTutorialOver = false;
    }

    private void Update()
    {
        if(scoreText != null)
        {
            int displayScore = Mathf.Max(0, Mathf.FloorToInt(GameManager.Instance.score));
            scoreText.text = displayScore.ToString();
            finalScoreText.text = displayScore.ToString();
        }

        print(Time.timeScale);

        timerTutorial -= Time.deltaTime;
        if (timerTutorial <= 0)
        {
            if(tutorialPanel != null)
            { 
                tutorialPanel.SetActive(false);
            }
            isTutorialOver = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            MainMenu();
            //PauseGame();
        }

        if (randomScene == 2)
        {
            GameManager.Instance.ChangeGameState(GameState.Target);
        }

        if (randomScene == 3)
        {
            GameManager.Instance.ChangeGameState(GameState.TargetMovil);
        }
    }
    public void StartGame()
    {
       
        SetPanelsFalse();
        GameManager.Instance.PlayMouseSound();
        //chooserPanel.SetActive(true);
        if(GameManager.Instance.lvlCounter <= 9)
        {
            GetRandomEasyGame();
        }
        else
        {
            GameOver();
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.lvlCounter = 0;
        GameManager.Instance.score = 0;
    }

    public void win()
    {
        Time.timeScale = 0f;
        //SetPanelsFalse();
        winPanel.SetActive(true);
    }
    public void GameOver()
    {
        SetPanelsFalse();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

    }
    public void GetRandomEasyGame()
    {
        
        int randomSceneIndex = Random.Range(1, 7);
        SceneManager.LoadScene(randomSceneIndex);
        GameManager.Instance.lvlCounter++;

    }

    public void GetRandomHardGame()
    {

        while (randomScene == -1 || randomScene == SceneManager.GetActiveScene().buildIndex)
        {
            randomScene = hardGames[Random.Range(0, hardGames.Length)];
        }

        SceneManager.LoadScene(randomScene); 
        Debug.Log("Escena difícil cargada: " + randomScene);
    }

    public void PauseGame()
    {
        //Time.timeScale = 0f;
        SetPanelsFalse();
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        //Time.timeScale = 1f;
        SetPanelsFalse();
        gamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        //Time.timeScale = 1f;
        gamePanel.SetActive(true);
    }

    public void SetPanelsFalse()
    {
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(false);
        gamePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
