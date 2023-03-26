using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Misc Class", menuName = "Item/Misc")]
public class MiscClass : ItemClass
{
    //Data specifiek voor misc items


    public override void Use(InventoryManager Caller)
    {
    }

    public override MiscClass GetMisc() { return this; }
    
}
