using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quests : Collectable
{
    public static Quests instance;

    private void Awake()
    {
        instance = this;

    }

    [SerializeField] private ItemClass itemToAdd;
    public Sprite Leeg;
    public bool questcomplete;


    protected override void OnCollect()
    {
        //InventoryClass inventory = new InventoryClass();
        //ItemClass itemToAdd = new ItemClass(); //create an instance of the ItemClass
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = Leeg;
            InventoryManager.instance.Add(itemToAdd);
            questcomplete = true;
            GameManager.instance.ShowText("collected!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }

    }



}

