using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationOnEvent : MonoBehaviour
{
    Animator an;
    [SerializeField] string triggerName = "play";
    private void Awake() {
        an = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        an.SetTrigger(triggerName);
    }
}
