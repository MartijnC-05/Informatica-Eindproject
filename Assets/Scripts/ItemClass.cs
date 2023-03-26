using System.Collections;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    //Data die voor alle items geldt
    public string itemName;
    public string hp;
    public string dmg;
    public Sprite itemIcon;
    public bool isStackable = true;

    public virtual void Use(InventoryManager Caller)
    {
        Debug.Log("Used Item");
    }
    public virtual ItemClass GetItem() { return this; }
    public virtual ToolClass GetTool() { return null; }
    public virtual MiscClass GetMisc() { return null; }
    public virtual ConsumableClass GetConsumable() { return null; }
}
