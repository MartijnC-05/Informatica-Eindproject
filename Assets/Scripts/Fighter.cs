using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public static Fighter instance;
    private void Awake()
    {
        instance = this;
    }

    //public fields
    public int hitpoint = 100;
    public int maxHitpoint = 100;
    public float pushRecoverySpeed = 0.2f;

    //Immunity zodat je niet instant dood gaat :)
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    protected virtual void RecieveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            //GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);
            NotificationAnim.instance.Pling();
            TextManager.instance.myText = dmg.damageAmount.ToString() + " damage done";

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    public virtual void Death()
    {
        DIEDIEDIE.instance.Died = true;
        Audio.instance.play();
    }
}
