using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;
    //private ItemClass[] droppable;
    [SerializeField] private ItemClass[] droppable;


    //Logic
    public float triggerLength = 1; //als afstand minder dan 1 is valt enemy je aan
    public float chaseLength = 5; //als enemy je meer dan 5 heeft achtervolgd stopt hij
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    public ContactFilter2D filter;

    protected override void Start()
    {
        base.Start();
        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            playerTransform = GameManager.instance.player.transform;
        }

        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    /*public static Enemy instance;

    private void Awake()
    {
        instance = this;
    }*/

    public void SuperStart()
    {
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }
    /*private void Awaken()
    {
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }*/

    private void FixedUpdate()
    {
        /*Debug.Log("playerTranform.position: " + playerTransform.position);
        Debug.Log("startingposition: " + startingPosition);
        Debug.Log("chaselength: " + chaseLength);*/

        //Player in range?
        if (playerTransform != null)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
            {
                if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                    chasing = true;

                if (chasing)
                {
                    if (!collidingWithPlayer)
                    {
                        UpdateMotor((playerTransform.position - transform.position).normalized);
                    }
                }

                else
                {
                    UpdateMotor(startingPosition - transform.position);
                }
            }
        }

        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //Overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if(hits[i].tag == "Fighter" && hits[i].name == "player")
            {
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }
    }

    public override void Death()
    {
        if (droppable.Length > 0)
        {
            ItemClass ToDrop = droppable[Random.Range(0, droppable.Length)];
            if(ToDrop != null)
            {
                InventoryManager.instance.Add(ToDrop);
            }
        }
        Destroy(gameObject);
        GameManager.instance.experience += xpValue;
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
