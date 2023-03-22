using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int health;


    // Data the game starts with when there is no data
    public GameData()
    {
        this.health = 100;
    }


}
