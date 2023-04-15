using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : CharacterMenu
{
    private Animator anim;
    public string thisScene;


    private void Start()
    {
        anim = GetComponent<Animator>();
        open = false;
    }

    public bool open;

    private void Update()
    {
        if (DIEDIEDIE.instance.Died == false)
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
                    open = false;
                }
            }
        }
    }

    public void BackToMainMenu()
    {
        GameManager.instance.SaveState();
        //SavingSystem.i.Save("saveSlot1");
        Portal.instance.currentScene = thisScene;
        SceneManager.LoadScene("Menu");
    }
}
