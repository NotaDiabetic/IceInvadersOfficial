using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject pausePanel;

    //---------Loading into the different Scenes
    public void LoadAScene(string MainMenu_IceInvaders)
    {
        SceneManager.LoadScene("Test Level");
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        PauseGame();
    }
    

    public void LoadWinScene(string TestLevel)
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoadLoseScene(string TestLevel)
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void LoadWinToMainMenu(string WinScene)
    {
        SceneManager.LoadScene("MainMenu_IceInvaders");
    }
    public void LoadLoseToMainMenu(string LoseScene)
    {
        SceneManager.LoadScene("MainMenu_IceInvaders");
    }
    public void LoadPauseToMainMenu(string TestLevel)
    {
        SceneManager.LoadScene("MainMenu_IceInvaders");
    }

    
    public void loadWinToGame(string WinScene)
    {
        SceneManager.LoadScene("Test Level");
    }
    public void loadloseToGame(string LoseScene)
    {
        SceneManager.LoadScene("Test Level");
    }
    public void loadPauseToGame()
    {
        pausePanel.SetActive(false);
        ResumeGame();
    }


    //---------Pause Game

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
