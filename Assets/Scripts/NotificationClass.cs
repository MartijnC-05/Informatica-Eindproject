using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new notification class", menuName = "Text/Notification")]
public class NotificationClass : TextClass
{
    // Start is called before the first frame update
    public override NotificationClass GetNotif() { return this; }
}
