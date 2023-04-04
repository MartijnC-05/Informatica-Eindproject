using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static SoundManager;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] Slider volumeSlider;

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

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log ("QUIT");
        Application.Quit();
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
