using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnLeftHandInteracter : AnimationOnEvent
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<LeftHandInteracter>())
        {
            PlayAnimation();
        }
    }
}
