using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        float random = Random.Range(45f, 135f);
        rb.velocity = new Vector2(Mathf.Cos(random), Mathf.Sin(random)) * Random.Range(25f, 40f);
    }
}
