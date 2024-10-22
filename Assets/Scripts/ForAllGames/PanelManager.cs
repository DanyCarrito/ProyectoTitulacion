using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject pausePanel;
    public GameObject gamePanel;
    public GameObject chooserPanel;
    public GameObject winPanel;
    
    private int randomScene = -1;
    private int[] hardGames = { 2, 3 };

    private void Update()
    {
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
        chooserPanel.SetActive(true);
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
        SceneManager.LoadScene(Random.Range(1, 1));
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
        SceneManager.LoadScene("ClickPrecision");
        Time.timeScale = 1f;
        gamePanel.SetActive(true);
    }

    public void SetPanelsFalse()
    {
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(false);
        gamePanel.SetActive(false);
    }
}
