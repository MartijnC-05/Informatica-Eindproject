using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : CharacterMenu
{
    public string[] sceneNames;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        open = false;
    }

    public bool open;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (open == false)
            {
                anim.SetTrigger("Show");
                open = true;
                UpdateMenu();
            }
            else if (open == true)
            {
                anim.SetTrigger("Hide");
                    open=false;
            }
        }        
    }

    public void BackToMainMenu()
    {
        GameManager.instance.SaveState();
        string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
        SceneManager.LoadScene(sceneName);
    }
}
