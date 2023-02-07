using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNote : Collectable
{
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    protected Animator anim;

    protected override void OnCollect()
    {
        anim.SetTrigger("NoteIsOpen");
    }

    
}
