using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(AnimationManager))]
[RequireComponent(typeof(Rigidbody2D))]
public class HandMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    AnimationManager an;
    SpriteRenderer[] sr;
    
    [SerializeField]
    private float speed = 10.0f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<AnimationManager>();
        sr = GetComponentsInChildren<SpriteRenderer>();
    }
    public void Move(float value)
    {
        an.Move(value != 0);
        if(value > 0)
        {
            foreach(SpriteRenderer s in sr)
            {
                s.flipX = true;
            }
        }
        else if (value < 0)
        {
            foreach(SpriteRenderer s in sr)
            {
                s.flipX = false;
            }
        }

        rb.velocity = Vector2.right * speed * value;
    }
}