using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DIEDIEDIE : MonoBehaviour
{
    public bool Died = false;

    public static DIEDIEDIE instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject objectToToggle;

    // Update is called once per frame
    void Update()
    {
        if (Died == true)
        {
            objectToToggle.SetActive(true);

        }
    }


    public void Restart()
    {
        Died = false;
        SceneManager.LoadScene("Menu");
    }


    public void Die()
    {
        Died = true;
        Debug.Log(Died);
        Audio.instance.played = false;
    }
}
