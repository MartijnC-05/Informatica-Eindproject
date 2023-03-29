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
        /*InventoryClass inventory = new InventoryClass();
        ItemClass itemToAdd = new ItemClass(); //create an instance of the ItemClass
        if (!collected)
        {
            InventoryManager inventory = new InventoryManager();
            bool success = inventory.Add(itemToAdd); //call the Add function on the inventory instance
            if (!success)
            {
                Debug.Log("Inventory is full!");
            }
        }
        /*collected = true;
        GetComponent<SpriteRenderer>().sprite = Leeg;
        //InventoryManager.Add(InventoryManager.MyItem);
        GameManager.instance.ShowText("collected!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
    }*/



    }
}
