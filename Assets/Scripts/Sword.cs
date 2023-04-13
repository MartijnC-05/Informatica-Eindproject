using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sword : Collectable
{
    [SerializeField] private ItemClass itemToAdd;
    public Sprite Leeg;
    

    protected override void OnCollect()
    {
        //InventoryClass inventory = new InventoryClass();
        //ItemClass itemToAdd = new ItemClass(); //create an instance of the ItemClass
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = Leeg;
            InventoryManager.instance.Add(itemToAdd);
            //GameManager.instance.ShowText("collected!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
            NotificationAnim.instance.Pling();
            TextManager.instance.myText = "collected!";
        }

    }



}

