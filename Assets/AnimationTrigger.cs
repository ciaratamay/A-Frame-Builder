using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animatorToTrigger;

    private void OnTriggerEnter( Collider other )
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animatorToTrigger.enabled = true;
        }
    }
}
