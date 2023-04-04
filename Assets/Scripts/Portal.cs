using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
        {
            //teleport the player
            GameManager.instance.SaveState();            
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            SceneManager.LoadScene(sceneName);
            Enemy.instance.SuperStart();
        }
    }
}
