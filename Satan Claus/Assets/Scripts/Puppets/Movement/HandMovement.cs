using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HandMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField]
    private float speed = 10.0f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(int value)
    {
         rb.velocity = Vector2.right * speed * value;
    }
}