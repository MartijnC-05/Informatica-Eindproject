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
}