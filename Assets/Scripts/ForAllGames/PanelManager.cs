using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject tutorialPanel;
    public GameObject pausePanel;
    public GameObject gamePanel;
    public GameObject chooserPanel;
    public GameObject winPanel;

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
        tutorialPanel.SetActive(true);
        isTutorialOver = false;
    }

    private void Update()
    {
        timerTutorial -= Time.deltaTime;
        if (timerTutorial <= 0)
        {
            tutorialPanel.SetActive(false);
            isTutorialOver = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            PauseGame();
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
        Time.timeScale = 1f;
        SetPanelsFalse();
        //chooserPanel.SetActive(true);
        GetRandomEasyGame();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void win()
    {
        Time.timeScale = 0f;
        //SetPanelsFalse();
        winPanel.SetActive(true);
    }
    public void GetRandomEasyGame()
    {
        int randomSceneIndex = Random.Range(1, 7);
        SceneManager.LoadScene(randomSceneIndex);
        GameManager.Instance.ChangeGameState(GameState.Precision);
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
        Time.timeScale = 0f;
        SetPanelsFalse();
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SetPanelsFalse();
        gamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
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
