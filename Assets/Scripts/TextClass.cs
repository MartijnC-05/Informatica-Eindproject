using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextClass : ScriptableObject
{
    [Header("Text Info")]
    //Data die voor alle text geldt
    public string textTitle;
    [TextArea(10, 100)]
    public string textContents;

    public virtual TextClass GetText() { return this; }
    public virtual NotificationClass GetNotif() { return null; }
    public virtual ConversationClass GetConversation() { return null; }
}
