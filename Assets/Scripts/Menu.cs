using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : CharacterMenu
{
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
}
