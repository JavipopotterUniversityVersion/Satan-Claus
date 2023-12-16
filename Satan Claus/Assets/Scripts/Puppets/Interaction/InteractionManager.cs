using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractionManager : MonoBehaviour
{
    public UnityEvent<Vector2> CanInteract = new UnityEvent<Vector2>();

    public void DetectInteractable(Vector2 position)
    {
        CanInteract?.Invoke(position);
    }
}

