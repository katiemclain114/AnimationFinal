using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{

    public void StartAttack()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void EndAttack()
    {
        GameManager.Instance.player.StopAttacking();
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
