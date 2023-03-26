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
        Debug.Log("Eat Consumable");
        Caller.Remove(this);
        GameManager.instance.player.hitpoint += healthAdded;
    }

    public override ConsumableClass GetConsumable() { return this; }
}
