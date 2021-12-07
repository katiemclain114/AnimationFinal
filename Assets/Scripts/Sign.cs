using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public Animator signText;    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        signText.Play("TextScaleUp");
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        signText.Play("TextScaleDown");
    }
}
