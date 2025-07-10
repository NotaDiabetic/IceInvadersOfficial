using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause_Manager : MonoBehaviour
{
    public GameObject pausePanel;

    //---------Alles Speziell f�r das Pausen_Menu--------

    private void Start()
    {
        pausePanel.SetActive(false);
    }


    public void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pausePanel.SetActive(true);
            PauseGame();
        }
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
