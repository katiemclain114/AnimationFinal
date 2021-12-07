using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackbleObject : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            anim.Play("AttackableObjHitAnim");
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    
}
