using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobiFriendAnim : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        RobiFriendFollow.instance.ResetRobi();
    }
}
