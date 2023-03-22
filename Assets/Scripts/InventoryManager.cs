using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;

    

    //Item dat wordt toegevoegd
    [SerializeField] private ItemClass itemToAdd;

    //Item dat wordt weggehaald
    [SerializeField] private ItemClass itemToRemove;

    [SerializeField] private SlotClass[] startingItems; 

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;

    //Kan dus andere functie zijn als er bijvoorbeeld wordt gecolide
    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        //items = new SlotClass[slots.Length];

        
        //set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        
        RefreshUI();
        Add(itemToAdd);//eerder genoemde item toevoegen
        Remove(itemToRemove);//eerder genoemde item weghalen
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // we clicked
        {
            //find closest slot (slot we clicked on)
            Debug.Log(GetClosestSlot().GetItem());
        }
    }


    #region Inventory Utils
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].GetQuantity() + ""; //alleen quantity geven bij stackbare items
                else
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = "";

            }
            catch 
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
        }
    }

    public bool Add(ItemClass item)
    {
        
        //check if inventory contains the item

        //als inventory item al heeft 1 aan stack toevoegen
        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem().isStackable)
            slot.AddQuantity(1);
        //anders nieuwe slot gebruiken
        else
        {
            //als er slot vrij is
            if (items.Count < slots.Length)
                items.Add(new SlotClass(item, 1));
            //anders
            else
                return false;
        }
        RefreshUI();
        return true;
    }
    
    public bool Remove(ItemClass item)
    {
        //items.Remove(item);
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if(temp.GetQuantity() > 1)
                temp.SubQuantity(1);
            else
            {
                SlotClass slotToRemove = new SlotClass();

                foreach (SlotClass slot in items)
                {
                    if (slot.GetItem() == item)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                items.Remove(slotToRemove);
            }
        }
        else
        {
            return false;
        }
        
        RefreshUI();
        return true;
    }

    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
                return slot;
        }

        return null;
    }
    #endregion Inventory Utils

    #region interacting with stuff
    private SlotClass GetClosestSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 64)
                return items[i];
        }

        return null;
    }
    #endregion
}
