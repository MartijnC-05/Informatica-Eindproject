using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMaster : Collectable
{
    public GameObject QuestObjectToToggle1;
    public GameObject QuestObjectToToggle2;
    private bool Done = false;
    public Animator anim;
    [SerializeField] private ItemClass itemToRemove;
    [SerializeField] private ItemClass itemToRemove2;

    public static QuestMaster instance;

    private void Awake()
    {
        instance = this;

    }

    /*private void Start()
    {
        anim = GetComponent<Animator>();
        //boxCollider = GetComponent<BoxCollider2D>();
    }*/
    public int questcomplete = 0;


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
        }
    }
}
