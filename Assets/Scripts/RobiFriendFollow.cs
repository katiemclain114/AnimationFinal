using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobiFriendFollow : MonoBehaviour
{
    public static RobiFriendFollow instance;

    public float speed;
    public Transform robiTarget;
    public bool gettingGear = false;
    [HideInInspector] public Transform attackTransform;
    public Animator anim;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!gettingGear)
        {
            transform.position = Vector2.MoveTowards(transform.position, robiTarget.position, speed * Time.deltaTime);
        }
        else
        {
            GoToAttack(attackTransform);
        }
    }

    private void GoToAttack(Transform target)
    {
        if (transform.position == target.position)
        {
            anim.SetBool("gettingGear", true);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void ResetRobi()
    {
        anim.SetBool("gettingGear", false);
        gettingGear = false;
    }
}
