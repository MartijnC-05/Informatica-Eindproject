using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    
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
