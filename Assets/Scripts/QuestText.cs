using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestText : MonoBehaviour
{


    public string questmessage = "yay";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (QuestMaster.instance.questcomplete == 2)
        {
            //GetChild(2).GetComponent<Text>().text = questmessage;
            GetComponent<Text>().text = questmessage;
        }
    }
}
