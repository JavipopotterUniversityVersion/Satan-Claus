using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ClientDialogHandler : MonoBehaviour, IInteractable
{
    string[] dialogues;
    public Transform myTransform => transform;
    Container _container;
    [SerializeField] int[] containerRequirements = new int[4];
    
    private void Awake() {
        _container = FindObjectOfType<Container>();
    }

    public void Interact()
    {
        if(CheckIfContainerIsEmpty())
        {
            DialoguesManager.dialoguesManager.ExecuteDialogViaKey(dialogues[0]);
        }
        else
        {
            _container.ResetContainer();
            if(CheckRequirements())
            {
                DialoguesManager.dialoguesManager.ExecuteDialogViaKey(dialogues[1]);
            }
            else
            {
                DialoguesManager.dialoguesManager.ExecuteDialogViaKey(dialogues[2]);
            }
        }
    }

    bool CheckRequirements()
    {
        for (int i = 0; i < containerRequirements.Length; i++)
        {
            if(containerRequirements[i] > _container.numberOfDrops[i])
            {
                return false;
            }
        }
        return true;
    }

    bool CheckIfContainerIsEmpty()
    {
        for (int i = 0; i < _container.numberOfDrops.Length; i++)
        {
            if(_container.numberOfDrops[i] > 0)
            {
                return false;
            }
        }
        return true;
    }
}
