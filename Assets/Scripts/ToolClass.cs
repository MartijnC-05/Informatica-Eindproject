using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Tool")]
    //Data specifiek voor tool items
    public ToolType toolType;

    public enum ToolType
    {
        weapon,
        axe
    }

    public int damagePoint = 1;
    public float pushForce = 2.0f;

    public override void Use(InventoryManager Caller)
    {
        Debug.Log("Damage: " + damagePoint);
        //GameManager.instance.ShowText("Damage: " + damagePoint, 25, Color.yellow, Input.mousePosition, Vector3.up * 25, 1.5f);
    }

    public override ToolClass GetTool() { return this; }
    
}
