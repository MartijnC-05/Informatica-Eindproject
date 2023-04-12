using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Mover, IDataPersistance
{
   private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }


    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    private void Update()
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

        if (moveDelta.x == 1)
        {
            anim.SetBool("WalkingRight", true);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingLeft", true); 
        }
        else if (moveDelta.x == -1)
        {
            anim.SetBool("WalkingLeft", true);
            anim.SetBool("WalkingRight", false);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("WalkingUp", false);
        }
        else if (moveDelta.y == 0.75)
        {
            anim.SetBool("WalkingUp", true);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        else if (moveDelta.y == -0.75)
        {
            anim.SetBool("WalkingDown", true);
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        else
        {          
            anim.SetBool("WalkingDown", false);
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
    }
}