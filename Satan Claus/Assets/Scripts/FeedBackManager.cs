using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackManager : MonoBehaviour
{
    [SerializeField] GameObject interactableFeedback;
    public List<Vector3> interactables = new List<Vector3>();
    bool _canInteract = true;
    bool canInteract
    {
        get => _canInteract;
        set
        {
            _canInteract = value;
            UpdateFeedBack();
        }
    }

    private void Start() {
        foreach(InteractionManager interaction in FindObjectsOfType<InteractionManager>())
        {
            interaction.CanInteract.AddListener(GetInteractable);
            interaction.CantInteract.AddListener(RemoveInteractable);
        }
        
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);
    }

    private void OnDestroy() {
        foreach(InteractionManager interaction in FindObjectsOfType<InteractionManager>())
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

    void GetInteractable(IInteractable interactable)
    {
        interactables.Add(interactable.myTransform.position);
        UpdateFeedBack();
    }

    void RemoveInteractable(IInteractable interactable)
    {
        interactables.Remove(interactable.myTransform.position);
        UpdateFeedBack();
    }

    void UpdateFeedBack()
    {
        if(canInteract && interactables.Count > 0)
        {
            interactableFeedback.SetActive(true);
            interactableFeedback.transform.position = interactables[^1] + Vector3.up * 2f;
        }
        else
        {
            interactableFeedback.SetActive(false);
        }
    }
}