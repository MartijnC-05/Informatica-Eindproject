using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;
    protected Animator anim;


    protected void Update()
    {
        if (DIEDIEDIE.instance.Died == false)
        {
            ySpeed = 0.75f;
            xSpeed = 1.0f;
        }
        else
        {
            ySpeed = 0;
            xSpeed = 0;
        }
    }


    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset MoveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // Sprite swap
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
            //anim.SetBool("WalkingRight", true);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
            //anim.SetBool("WalkingLeft", true);
        }
        else
        {
            //anim.SetBool("WalkingLeft", false);
            //anim.SetBool("WalkingRight", false);
        }

        //Add push
        moveDelta += pushDirection;

        //reduce push force every frame
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //Move in direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // MOVEMENT
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // MOVEMENT
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
