using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudButton : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        openbutton = false;
    }
    public bool openbutton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (openbutton == false)
            {
                anim.SetTrigger("Open");
                openbutton = true;
            }
            else if (openbutton == true)
            {
                anim.SetTrigger("Closed");
                openbutton = false;
            }  
        }
    }
}
