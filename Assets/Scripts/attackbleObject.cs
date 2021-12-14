using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackbleObject : MonoBehaviour
{
    private Animator anim;
    private RobiFriendFollow rff;
    public Transform robiTarget;

    void Start()
    {
        rff = RobiFriendFollow.instance;
        anim = GetComponent<Animator>();
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            if (!rff.gettingGear)
            {
                rff.attackTransform = robiTarget;
                rff.gettingGear = true;
            }
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    
}
