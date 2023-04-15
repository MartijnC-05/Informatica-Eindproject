using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using static SoundManager;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] Slider volumeSlider;

    public static MainMenu instance;
    private void Awake()
    {
        instance = this;
    }


        void Start()
    {
        /*if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            SoundManager.instance.Load();
        }

        else
        {
            SoundManager.instance.Load();
        }*/
        //volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //DataPersistanceManager.instance.NewGame();
        PlayerPrefs.DeleteAll();
    }

    public void LoadGame()
    {
        //SavingSystem.i.Load("saveSlot1");
        Debug.Log("Load");

        SceneManager.LoadScene(Portal.instance.currentScene);
    }

    public GameObject ToggleBoggle;

    /*void Update()
    {
        if(Portal.instance.currentScene != null)
        {
            ToggleBoggle.SetActive(false);
        }
        else
        {
            ToggleBoggle.SetActive(true);
        }
    }*/

    public void QuitGame()
    {
        Debug.Log ("QUIT");
        Application.Quit();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }


    // public void NewGame()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //     DataPersistanceManager.instance.NewGame();
    // }

    // public void LoadGame()
    // {
    //     DataPersistanceManager.instance.LoadGame();
    // }

    // public void SaveGame()
    // {
    //     DataPersistanceManager.instance.SaveGame();
    //}

}
