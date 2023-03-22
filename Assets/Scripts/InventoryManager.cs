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

    private SlotClass[] items;

    private GameObject[] slots;

    //Kan dus andere functie zijn als er bijvoorbeeld wordt gecolide
    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];
        //items = new SlotClass[slots.Length];

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }

        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }

        //set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        
        RefreshUI();
        Add(itemToAdd);//eerder genoemde item toevoegen
        //Remove(itemToRemove);//eerder genoemde item weghalen
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // we clicked
        {
            //find closest slot (slot we clicked on
            //Debug.Log(GetClosestSlot());
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
            for(int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null) //empty slot
                { 
                    items[i].AddItem(item, 1);
                    break;
                }
            }
 /*           //als er slot vrij is
            if (items.Count < slots.Length)
                items.Add(new SlotClass(item, 1));
            //anders
            else
                return false;*/
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
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }
                items[slotToRemoveIndex].Clear();
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
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i].GetItem() == item && items[i].GetItem() != null)
                return items[i];
        }
        return null;
    }
    
    #endregion Inventory Utils

    #region interacting with stuff
    private SlotClass GetClosestSlot()
    {
        Debug.Log(Input.mousePosition);

        //for (int i = 0; i < slots.Length; i++)
        //{
        //    if (Vector2.Distance(slots[i].tranform.position, Input.mousePosition) <= 32)
        //        return items[i];
        //}

        return null;
    }
    #endregion
}
