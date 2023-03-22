using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int maxInventorySlots = 20;
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public bool AddItem(InventoryItem item)
    {
        if (inventoryItems.Count < maxInventorySlots)
        {
            inventoryItems.Add(item);
            return true;
        }

        return false;
    }

    public bool RemoveItem(InventoryItem item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            return true;
        }

        return false;
    }

    public bool ConsumeItem(InventoryItem item)
    {
        if (inventoryItems.Contains(item))
        {
            item.Consume();
            inventoryItems.Remove(item);
            return true;
        }

        return false;
    }
}

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public Sprite itemImage;
    public int itemID;
    public int quantity;

    public void Consume()
    {
        // Put code here for what happens when the item is consumed
    }
}
