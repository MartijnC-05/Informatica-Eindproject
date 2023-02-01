using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNote : Collectable
{
    public Sprite Textnote;

    protected override void OnCollect()
    {
        GetComponent<SpriteRenderer>().sprite = Textnote;
    }

    SpriteRenderer rend;

}