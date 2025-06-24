using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //---------Loading into the different Scenes
    public void LoadAScene(string MainMenu_IceInvaders)
    {
        SceneManager.LoadScene("Test Level");
        
    }

    public void LoadPauseScene(string TestLevel)
    {
        SceneManager.LoadScene("PauseScene");
        SaveData();
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
    public void LoadPauseToMainMenu(string PauseScene)
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
    public void loadPauseToGame(string PauseScene)
    {
        SceneManager.LoadScene("Test Level");
        LoadData();
    }
    
    //--------Saving Data for the PauseScene/LevelScene

    public void SaveData()
    {
        //Important data needing to be saved here
    }

    public void LoadData()
    {
        //Saved data the player was in before pausing the game
    }
}
