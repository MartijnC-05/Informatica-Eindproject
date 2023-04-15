using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour, IDataPersistance
{
    //Text Fields
    public Text healthText;
    public int health = 100;

    //Logic
    public RectTransform hpBar;
    public player player;

    public static CharacterMenu instance;

    private void Awake()
    {
        instance = this;
    }

        private void Update()
    {
        //HP bar
        float HealthPercentage = (float)health / 100;

        if (GameManager.instance != null && player != null)
        {
            if (player.hitpoint >= 100)
            {
                player.hitpoint = 100;
            }

            if (player.hitpoint <= 0)
            {
                player.hitpoint = 0;
                Fighter.instance.Death();
            }
            health = player.hitpoint;
        }

        healthText.text = health.ToString() + "%";
        hpBar.localScale = new Vector3(HealthPercentage, 1, 1);
    }

    public void LoadData(GameData data)
    {
        this.health = data.health;
    }

    public void SaveData(ref GameData data)
    {
        data.health = this.health;
    }

    //Update the character info als menu wordt geopend
    public void UpdateMenu()
    {
        
    }
}
