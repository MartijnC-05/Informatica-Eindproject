using System.Collections;
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

    

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return this; }
    public override MiscClass GetMisc() { return null; }
    public override ConsumableClass GetConsumable() { return null; }
}
