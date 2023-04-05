using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private GameObject[] texts;

    private Animator anim;

    public static TextManager instance;

    private void Awake()
    {
        instance = this;
    }

    /*public void TextScript(string msg, int fontsize, Color color, Vector3 position, float duration)
    {
        floatingTextManager.Show(msg, fontsize, color, position, duration);
    }*/

    public string myText;
    public float textDuration = 5f;  // Duration in seconds that the text will be displayed


    private Text textComponent;
    private bool isTextScheduledToClear = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        textComponent = GetComponent<Text>();
        textComponent.text = "";
    }

    private void Update()
    {
        textComponent.text = myText;
        ResetText();
    }

    private void ResetText()
    {
        if (!isTextScheduledToClear)
        {
            Invoke("ClearText", textDuration);
            isTextScheduledToClear = true;

        }
    }

    private void ClearText()
    {
        myText = "";
        isTextScheduledToClear = false;
    }

    
}


