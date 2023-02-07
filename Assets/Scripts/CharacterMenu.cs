using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //Text Fields
    public Text healthText;
    public int health = 100;

    //Logic
    public RectTransform hpBar;

    private void Update()
    {
        //HP bar
        float HealthPercentage = (float)health / 100;


        health = GameManager.instance.player.hitpoint * 10;
        healthText.text = health.ToString() + "%";
        hpBar.localScale = new Vector3(HealthPercentage, 1, 1);
    }

    //Update the character info als menu wordt geopend
    public void UpdateMenu()
    {
        
    }
}
