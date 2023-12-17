using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandMovement : HandMovement
{
    [SerializeField] private bool _moving = false;
    public bool moving
    {
        get { return _moving; }
        set 
        { 
            if (!value) Move(0);
            _moving = value;
        }
    }
    Vector3 movementDirection;

    private void Update()
    {
        if(moving)
        {
            movementDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            movementDirection = movementDirection.normalized;
            Move(movementDirection.x);
        }
    }
}
