using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMaster : Collectable
{
    public GameObject QuestObjectToToggle1;
    public GameObject QuestObjectToToggle2;
    public GameObject QuestObjectToToggle3;
    public bool Done = false;
    private bool Done2 = false;
    public Animator anim;
    [SerializeField] private ItemClass itemToRemove;
    [SerializeField] private ItemClass itemToRemove2;
    [SerializeField] private ItemClass itemToRemove3;
    [SerializeField] private ItemClass itemToRemove4;
    [SerializeField] private ItemClass itemToRemove5;
    [SerializeField] private ItemClass itemToRemove6;
    [SerializeField] private ItemClass itemToRemove7;

    /*private void Start()
    {
        anim = GetComponent<Animator>();
        //boxCollider = GetComponent<BoxCollider2D>();
    }*/

    public static QuestMaster instance;

    private void Awake()
    {
        instance = this;

    }
    public int questcomplete = 0;
    public int quest2completion = 0;

    protected override void OnCollect()
    {
        if (!collected)
        {
            if (questcomplete == 2)
            {
                if (Done == false)
                {
                    anim = GetComponent<Animator>();
                    anim.SetTrigger("Explode");
                    Audio.instance.Boom();
                    InventoryManager.instance.Remove(itemToRemove);
                    InventoryManager.instance.Remove(itemToRemove2);
                    QuestObjectToToggle1.SetActive(false);
                    QuestObjectToToggle2.SetActive(false);
                    Done = true;
                }
            }
            else if (quest2completion != 5)
            {
                NotificationAnim.instance.Pling();
                TextManager.instance.myText = "You don't have all the parts yet!";

            }
            else if (quest2completion == 5)
            {
                if (Done2 == false)
                {
                    InventoryManager.instance.Remove(itemToRemove3);
                    InventoryManager.instance.Remove(itemToRemove4);
                    InventoryManager.instance.Remove(itemToRemove5);
                    InventoryManager.instance.Remove(itemToRemove6);
                    InventoryManager.instance.Remove(itemToRemove7);
                    QuestObjectToToggle3.SetActive(false);
                    Done2 = true;
                }
            }
        }
    }
}
