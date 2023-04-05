using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable Class", menuName = "Item/Consumable")]
public class ConsumableClass : ItemClass
{
    [Header("Consumable")]
    public int healthAdded;
    //Data specifiek voor Consumable items

    public override void Use(InventoryManager Caller)
    {
        if (GameManager.instance.player.hitpoint == 10)
        {
            NotificationAnim.instance.Pling();
            Debug.Log("Health is full");
            TextManager.instance.myText = "Health is full";
        }
        else
        {
            NotificationAnim.instance.Pling();
            Debug.Log("Eat Consumable");
            TextManager.instance.myText = "Eat Consumable";
            Caller.Remove(this);
            GameManager.instance.player.hitpoint += healthAdded;
        }
    }

    public override ConsumableClass GetConsumable() { return this; }
}
