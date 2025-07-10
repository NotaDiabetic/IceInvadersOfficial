using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Manager : MonoBehaviour
{
    public GameObject pausePanel;

    //---------Alles Speziel für das Pausen_Menu--------

    private void Start()
    {
        pausePanel.SetActive(false);
    }


    public void Pause()
    {
        pausePanel.SetActive(true);
        PauseGame();
    }
    
      public void LoadPauseToMainMenu(string TestLevel)
    {
        SceneManager.LoadScene("MainMenu_IceInvaders");
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
