using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Collectable
{
    public Sprite Leeg;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = Leeg;
            //GameManager.instance.ShowText("collected!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}
