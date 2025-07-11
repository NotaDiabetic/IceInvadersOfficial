using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause_Manager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    [SerializeField] EnemySpawner spawner;

    //---------Alles Speziell f�r das Pausen_Menu--------

    private void Start()
    {
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pausePanel.SetActive(true);
            PauseGame();
        }

         if (spawner.spawnedEnemies >= spawner.maxEnemies && GameObject.FindGameObjectsWithTag("Snowman").Length == 0)
        {
            Debug.Log(message: "Waga Baga Bobo");
            WinGame();
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

    public void WinGame()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu(string TestLevel)
    {
        SceneManager.LoadScene("MainMenu_IceInvaders");
    }
}
