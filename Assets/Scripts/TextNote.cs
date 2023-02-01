using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteAppear : MonoBehaviour
{
    [SerializeField]
    private Image _noteImage;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            _noteImage.enabled = true;
            Debug.Log("visible ");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            _noteImage.enabled = false;
            Debug.Log("invisible ");
        }
    }
}