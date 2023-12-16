using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandMovement : HandMovement
{
    private bool _moving = false;
    public bool moving
    {
        get { return _moving; }
        set { if (!value) rb.velocity = Vector3.zero; }
    }
    Vector3 movementDirection;

    private void Update()
    {
        if(_moving)
        {
            movementDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            movementDirection = movementDirection.normalized;
            Move(movementDirection.x);
        }
    }
}
