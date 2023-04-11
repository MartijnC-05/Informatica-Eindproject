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
        if (moveDelta.x > 0)
        {
            anim.SetBool("WalkingRight", true);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingLeft", false); 
        }
        else if (moveDelta.x < 0)
        {
            anim.SetBool("WalkingLeft", true);
            anim.SetBool("WalkingRight", false);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("WalkingUp", false);
        }
        else if (moveDelta.y > 0)
        {
            anim.SetBool("WalkingUp", true);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        else if (moveDelta.y < 0)
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