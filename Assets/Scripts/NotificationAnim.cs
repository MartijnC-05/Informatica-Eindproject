using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationAnim : MonoBehaviour
{
    private Animator anim;

    public static NotificationAnim instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pling()
    {
        anim.SetTrigger("Pling");
    }
}
