using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Collectable
{
    protected override void OnCollect()
    {
        Debug.Log("Water");
    }

}
