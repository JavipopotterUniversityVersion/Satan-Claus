using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnRightHandInteracter : AnimationOnEvent
{
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<RightHandInteracter>())
        {
            PlayAnimation();
        }
    }
}
