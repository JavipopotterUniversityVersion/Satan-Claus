using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    IInteractable interactable;

    private void Start() {
        foreach(InteractionManager interaction in FindObjectsOfType<InteractionManager>())
        {
            interaction.CanInteract.AddListener(GetInteractable);
        }
    }

    public void Interact()
    {
        if (interactable != null) interactable.Interact();
    }

    void GetInteractable(IInteractable interactable)
    {
        this.interactable = interactable;
    }
}
