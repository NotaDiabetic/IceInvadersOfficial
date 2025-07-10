using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Script : MonoBehaviour
{
    [Header("___Settings___")]
    
    //[SerializeField] private AudioMixer audiomixer;

    [SerializeField] public Slider masterVolumeSlider;
    [SerializeField] private TMPro.TextMeshProUGUI masterPercentText;
    
    [SerializeField] public Slider sfxVolumeSlider;
    [SerializeField] private TMPro.TextMeshProUGUI sfxPercentText;
    
    [SerializeField] public Slider effectVolumeSlider;
    [SerializeField] private TMPro.TextMeshProUGUI effectPercentText;
    
    [Header("___Fullscreen Toggle___")]

    [SerializeField] public Toggle fullscreenToggle;
    private bool getFullBoolFromToggle;
    
    
    //------------Player Pref's---------

    //Did the game run for the first time
    private string firstRunInPP = "IsTheGameRunningForTheFirstTime";
    private int firstRunInt = 0;
    
    
    //checking if Fullscreen is on or off
    private string FullscreenInPP = "isItFullscreen";
    private int FullscreenInt = 0; //0 = Game not run yet

    //checking masterVolume
    private string masterVolume = "masterVolume";
    private float masterVolumeFloat = 0.5f; 
    
    //checking sfxVolume
    private string sfxVolume = "sfxVolume";
    private float sfxVolumeFloat = 0.5f;
    
    //checking effectVolume
    private string effectVolume = "effectVolume";
    private float effectVolumeFloat = 0.5f;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Checking if the game is running for the first time
        if (firstRunInt == 0) 
        {
            LoadDefaultSettings();
            PlayerPrefs.SetInt(firstRunInPP, 1);
        }
        else
        {
            LoadSettingsFromPP();
        }
    }
    
    //----------Player Pref's Functions---------

    #region Player Prefs
    
    private void LoadDefaultSettings()
    {
        PlayerPrefs.SetInt("FirstRunInPP", 0); //firstRun
        
        PlayerPrefs.SetInt("isFullscreen", 0); //Fullscreen
        
        PlayerPrefs.SetFloat(masterVolume, 1);
        
        PlayerPrefs.SetFloat(sfxVolume, 1);
        
        PlayerPrefs.SetFloat(effectVolume, 1);
        
        LoadSettingsFromPP();
    }

    private void LoadSettingsFromPP()
    {
       firstRunInt = PlayerPrefs.GetInt(firstRunInPP, firstRunInt); 
       
       FullscreenInt = PlayerPrefs.GetInt(FullscreenInPP, FullscreenInt);
       
       masterVolumeFloat = PlayerPrefs.GetFloat(masterVolume, masterVolumeFloat);
       
       sfxVolumeFloat = PlayerPrefs.GetFloat(sfxVolume, sfxVolumeFloat);
       
       effectVolumeFloat = PlayerPrefs.GetFloat(effectVolume, effectVolumeFloat);
    }
    
    #endregion
    
    
    
    //------Settings Functions------
    #region Settings
    
    //Fullscreen Function
    public void ChangeFullscreenState()
    {
        //when user clicks the toggle in Unity
        getFullBoolFromToggle = fullscreenToggle.isOn;
        Debug.Log ("Changing Fullscreen state to: " + getFullBoolFromToggle);

        if (getFullBoolFromToggle == true)
        {
            PlayerPrefs.SetInt(FullscreenInPP, 0);
            
            Screen.fullScreen = true;
        }
        else
        {
            PlayerPrefs.SetInt(FullscreenInPP, 1);
            
            Screen.fullScreen = false;
        }
    }
    
    
    //master Volume
    public void ChangeMasterVolume()
    {
        masterVolumeFloat = masterVolumeSlider.value; //adjusting the Volume with the Slider
        
        //audiomixer.SetFloat("masterVolume", Mathf.Log10(masterVolumeFloat) * 20);
        
        masterPercentText.text = ((masterVolumeFloat * 100).ToString("0") + "%");
        
        PlayerPrefs.SetFloat(masterVolume, masterVolumeFloat);
    }
    
    
    //sfx Volume
    public void ChangeSfxVolume()
    {
        sfxVolumeFloat = sfxVolumeSlider.value;
        
        //audiomixer.SetFloat("sfxVolume", Mathf.Log10(sfxVolumeFloat) * 20);
        
        sfxPercentText.text = ((sfxVolumeFloat * 100).ToString("0") + "%");
        
        PlayerPrefs.SetFloat(sfxVolume, sfxVolumeFloat);
    }
    
    
    //effect Volume
    public void ChangeEffectVolume()
    {
        effectVolumeFloat = effectVolumeSlider.value;
        
        //audiomixer.SetFloat("sfxVolume", Mathf.Log10(sfxVolumeFloat) * 20);
        
        effectPercentText.text = ((effectVolumeFloat * 100).ToString("0") + "%");
        
        PlayerPrefs.SetFloat(effectVolume, effectVolumeFloat);
    }

    #endregion


    //--------Connecting Scenes-------
    #region Scene Connection
    public void LoadAScene(string MainMenu_IceInvaders)
    {
        SceneManager.LoadScene("Test Level");
    }

    public void LoadWinScene(string TestLevel)
    {
        SceneManager.LoadScene("MainMenu_IceInvaders");
        
    }

    public void LoadLoseScene(string TestLevel)
    {
        SceneManager.LoadScene("LoseScene");
    }


    public void loadWinToGame(string WinScene)
    {
        SceneManager.LoadScene("Test Level");
    }
    public void loadloseToGame(string LoseScene)
    {
        SceneManager.LoadScene("Test Level");
    }

    #endregion

    public void QuitGame()
    {
        Application.Quit();
    }
}


