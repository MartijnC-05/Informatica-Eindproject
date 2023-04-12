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

    /*private void Start()
    {
        anim = GetComponent<Animator>();
        //boxCollider = GetComponent<BoxCollider2D>();
    }*/

    protected override void OnCollect()
    {
        if (!collected)
        {
            if (Quests.instance.questcomplete == true)
            {
                if (Done == false)
                {
                    anim = GetComponent<Animator>();
                    anim.SetTrigger("Explode");
                    Audio.instance.Boom();
                    InventoryManager.instance.Remove(itemToRemove);
                    QuestObjectToToggle1.SetActive(false);
                    QuestObjectToToggle2.SetActive(false);
                    Done = true;
                }
            }
        }
    }
}
