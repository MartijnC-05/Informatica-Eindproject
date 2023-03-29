using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new conversation class", menuName = "Text/Conversation")]
public class ConversationClass : TextClass
{
    // Start is called before the first frame update
    public override ConversationClass GetConversation() { return this; }

}
