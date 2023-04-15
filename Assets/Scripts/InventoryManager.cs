using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;

    public static InventoryManager instance;

    //Item dat wordt toegevoegd
    [SerializeField] private ItemClass itemToAdd;

    //Item dat wordt weggehaald
    [SerializeField] private ItemClass itemToRemove;

    [SerializeField] private SlotClass[] startingItems; 

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;

    private void Awake()
    {
        instance = this;

    }

    private Vector2 mousePos;

    //Kan dus andere functie zijn als er bijvoorbeeld wordt gecolide
    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        //items = new SlotClass[slots.Length];

        // Initialize mousePos using Screen.width and Screen.height
        //mousePos = Input.mousePosition;
        //float xNorm = mousePos.x / Screen.width;
        //float yNorm = mousePos.y / Screen.height;
        //mousePos = new Vector2(xNorm, yNorm);

        //set all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        
        RefreshUI();
        Add(itemToAdd);//eerder genoemde item toevoegen
        Remove(itemToRemove);//eerder genoemde item weghalen
    }

    private void Update()
    {
        Vector2 normScreenPos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

        if (Input.GetMouseButtonDown(0)) // we clicked
        {

            //item gebruiken
            if (GetClosestSlot(normScreenPos) != null)
            {
                GetClosestSlot(normScreenPos).GetItem().Use(this); 
            }
            /* (GetClosestSlot() != null)
            {
                Debug.Log(GetClosestSlot().GetItem());
            }
            else
            {
                Debug.Log("no item");
            }*/
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
                slots[i].transform.GetChild(4).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "use";
                slots[i].transform.GetChild(6).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(6).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;                
                slots[i].transform.GetChild(7).GetComponent<Text>().text = items[i].GetItem().itemName;
                slots[i].transform.GetChild(5).GetComponent<Text>().text = "Amount:";
                if (items[i].GetItem().isStackable) //consumable
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].GetQuantity() + ""; //alleen quantity geven bij stackbare items
                    slots[i].transform.GetChild(3).GetComponent<Text>().text = "";
                    slots[i].transform.GetChild(2).GetComponent<Text>().text = items[i].GetItem().hp;
                    slots[i].transform.GetChild(5).GetComponent<Text>().text = "Amount:";

                }
                else if (items[i].GetItem().itemName == "Lighter" || items[i].GetItem().itemName == "Dynamite" || items[i].GetItem().itemName == "Part 1" || items[i].GetItem().itemName == "Part 2" || items[i].GetItem().itemName == "Part 3" || items[i].GetItem().itemName == "Part 4" || items[i].GetItem().itemName == "Part 5")
                {
                    slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                    slots[i].transform.GetChild(5).GetComponent<Text>().text = "";
                    slots[i].transform.GetChild(4).GetComponent<Image>().sprite = null;
                    slots[i].transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "";
                    slots[i].transform.GetChild(4).GetComponent<Image>().enabled = false;
                }
                else //weapon
                {
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                    slots[i].transform.GetChild(3).GetComponent<Text>().text = items[i].GetItem().dmg;
                    slots[i].transform.GetChild(2).GetComponent<Text>().text = "";
                    slots[i].transform.GetChild(5).GetComponent<Text>().text = "";
                }
            }
            catch 
            {
                slots[i].transform.GetChild(6).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(6).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(4).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(4).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(3).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(5).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(7).GetComponent<Text>().text = "";

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
    /*private SlotClass GetClosestSlot()
    {
        SlotClass closestSlot = null;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < slots.Length; i++)
        {
            RectTransform rectTransform = slots[i].GetComponent<RectTransform>();
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);

            Rect slotRect = new Rect(corners[0].x, corners[0].y, rectTransform.rect.width, rectTransform.rect.height);
            if (slotRect.Contains(Input.mousePosition))
            {
                float distance = Vector2.Distance(slots[i].transform.position, Input.mousePosition);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestSlot = items[i];
                }
            }
        }
        
        return closestSlot;
        
    }*/


    private SlotClass GetClosestSlot(Vector2 normScreenPos)
    {
        SlotClass closestSlot = null;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < slots.Length; i++)
        {
            RectTransform rectTransform = slots[i].GetComponent<RectTransform>();
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);

            Rect slotRect = new Rect(
                corners[0].x / Screen.width, // left
                corners[0].y / Screen.height, // bottom
                rectTransform.rect.width / Screen.width, // width
                rectTransform.rect.height / Screen.height // height
            );

            if (slotRect.Contains(normScreenPos))
            {
                float distance = Vector2.Distance(slots[i].transform.position, Input.mousePosition);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestSlot = items[i];
                }
            }
        }

        return closestSlot;
    }

    #endregion

}

//Debug.Log(Vector2.Distance(slots[i].transform.position, Input.mousePosition));

//if (Vector2.Distance(new Vector2(slots[i].transform.position.x, slots[i].transform.position.y) - slots[i].GetComponent<RectTransform>().pivot * slots[i].GetComponent<RectTransform>().rect.height, Input.mousePosition) <= 70)
