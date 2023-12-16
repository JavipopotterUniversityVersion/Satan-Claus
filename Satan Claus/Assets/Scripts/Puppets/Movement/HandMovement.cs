using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Moverse(int value)
    {
         rb.velocity = Vector2.right * speed * value;
    }
}