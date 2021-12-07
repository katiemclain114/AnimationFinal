using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobiFriendFollow : MonoBehaviour
{
    public float speed;
    public Transform robiTarget;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, robiTarget.position, speed * Time.deltaTime);
    }
}
