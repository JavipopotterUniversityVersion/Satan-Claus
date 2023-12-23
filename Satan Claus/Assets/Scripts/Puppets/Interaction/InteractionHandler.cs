using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public List<IInteractable> interactables = new List<IInteractable>();
    bool canInteract = true;

    private void OnEnable() {
        foreach(InteractionManager interaction in FindObjectsOfType<InteractionManager>(true))
        {
            interaction.CanInteract.AddListener(GetInteractable);
            interaction.CantInteract.AddListener(RemoveInteractable);
        }
        
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);
    }

    private void OnDisable() {
        foreach(InteractionManager interaction in FindObjectsOfType<InteractionManager>(true))
        {
            interaction.CanInteract.RemoveListener(GetInteractable);
            interaction.CantInteract.RemoveListener(RemoveInteractable);
        }

        GameManager.GM.OnStateEnter.RemoveListener(OnStateEnter);
        GameManager.GM.OnStateExit.RemoveListener(OnStateExit);
    }

    void OnStateEnter(GameState state)
    {
        switch(state)
        {
            case GameState.Dialog:
                canInteract = false;
                break;
            case GameState.Cooking:
                canInteract = false;
                break;
        }
    }

    void OnStateExit(GameState state)
    {
        switch(state)
        {
            case GameState.Dialog:
                canInteract = true;
                break;
            case GameState.Cooking:
                canInteract = true;
                break;
        }
    }

    public void Interact()
    {
        if (canInteract && interactables.Count > 0)
        {
            interactables[^1].Interact();
        }
    }

    void GetInteractable(IInteractable interactable)
    {
        interactables.Add(interactable);
    }

    void RemoveInteractable(IInteractable interactable)
    {
        interactables.Remove(interactable);
    }
}
