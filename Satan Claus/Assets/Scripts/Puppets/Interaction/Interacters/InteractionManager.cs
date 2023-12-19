using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractionManager : MonoBehaviour
{
    public UnityEvent<IInteractable> CanInteract = new UnityEvent<IInteractable>();
    public UnityEvent<IInteractable> CantInteract = new UnityEvent<IInteractable>();

    public void DetectInteractable(IInteractable interactable)
    {
        CanInteract?.Invoke(interactable);
    }

    public void StopDetectingInteractable(IInteractable interactable)
    {
        CantInteract?.Invoke(interactable);
    }
}

