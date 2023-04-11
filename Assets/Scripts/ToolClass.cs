using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //Weapon.instance.ChangeWeapon();
        NotificationAnim.instance.Pling();
        Debug.Log("Damage: " + damagePoint);
        TextManager.instance.myText = "Damage: " + damagePoint.ToString();
        //GameManager.instance.ShowText("Damage: " + damagePoint, 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
    }

    public override ToolClass GetTool() { return this; }
    
}
