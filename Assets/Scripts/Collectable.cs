using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    //Logic
    protected bool collected;

    //Alleen als player het aanraakt wordt het gecollect (zodat een andere collision box het niet activeert)
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
            OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
