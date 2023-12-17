using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    IInteractable interactable;
    IInteractable lastInteractable;

    private void Start() {
        foreach(InteractionManager interaction in FindObjectsOfType<InteractionManager>())
        {
            interaction.CanInteract.AddListener(GetInteractable);
        }

        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);
    }

    void OnStateEnter(GameState state)
    {
        switch(state)
        {
            case GameState.Dialog:
                lastInteractable = interactable;
                interactable = null;
                break;
        }
    }

    void OnStateExit(GameState state)
    {
        switch(state)
        {
            case GameState.Dialog:
                interactable = lastInteractable;
                break;
        }
    }

    public void Interact()
    {
        if (interactable != null) 
        {
            interactable.Interact();
            interactable = null;
        }
    }

    void GetInteractable(IInteractable interactable)
    {
        this.interactable = interactable;
    }
}
