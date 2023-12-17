using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ClientDialogHandler : MonoBehaviour, IInteractable
{
    [SerializeField] string[] dialogues;
    public Transform myTransform => transform;
    [SerializeField] CupInfo cupInfo;
    [SerializeField] int[] containerRequirements = new int[4];

    public void Interact()
    {
        if(CheckIfContainerIsEmpty())
        {
            DialoguesManager.dialoguesManager.ExecuteDialogViaKey(dialogues[0]);
        }
        else
        {
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
            if(containerRequirements[i] > cupInfo.numberOfDrops[i])
            {
                return false;
            }
        }
        return true;
    }

    bool CheckIfContainerIsEmpty()
    {
        for (int i = 0; i < cupInfo.numberOfDrops.Length; i++)
        {
            if(cupInfo.numberOfDrops[i] > 0)
            {
                return false;
            }
        }
        return true;
    }
}
