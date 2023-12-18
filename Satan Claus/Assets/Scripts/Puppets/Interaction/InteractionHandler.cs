using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public IInteractable interactable;
    IInteractable lastInteractable;

    private void Start() {
        foreach(InteractionManager interaction in FindObjectsOfType<InteractionManager>())
        {
            interaction.CanInteract.AddListener(GetInteractable);
            interaction.CantInteract.AddListener(GetInteractable);
        }

        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);
    }

    private void OnDestroy() {
        foreach(InteractionManager interaction in FindObjectsOfType<InteractionManager>())
        {
            interaction.CanInteract.RemoveListener(GetInteractable);
            interaction.CantInteract.RemoveListener(GetInteractable);
        }

        GameManager.GM.OnStateEnter.RemoveListener(OnStateEnter);
        GameManager.GM.OnStateExit.RemoveListener(OnStateExit);
    }

    void OnStateEnter(GameState state)
    {
        switch(state)
        {
            case GameState.Dialog:
                lastInteractable = interactable;
                interactable = null;
                break;
            case GameState.Cooking:
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
            case GameState.Cooking:
                interactable = lastInteractable;
                break;
        }
    }

    public void Interact()
    {
        if (interactable != null) 
        {
            interactable.Interact();
        }
    }

    void GetInteractable(IInteractable interactable)
    {
        this.interactable = interactable;
    }
}
