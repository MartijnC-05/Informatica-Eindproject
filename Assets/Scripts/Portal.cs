using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;
    public string currentScene = "Scene1";

    public static Portal instance;
    private void Awake()
    {
        instance = this;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
        {
            //teleport the player
            GameManager.instance.SaveState();            
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            currentScene = sceneName;
            Debug.Log(sceneName);
            SceneManager.LoadScene(sceneName);
            //Enemy.instance.SuperStart();
        }
    }
}
