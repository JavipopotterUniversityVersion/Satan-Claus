using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishScript : MonoBehaviour
{
    [SerializeField] int speed;
    private Vector2 randomDirection = new Vector2(Random.value, Random.Range(0,35));

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.velocity = randomDirection.normalized * speed;
    }
}
