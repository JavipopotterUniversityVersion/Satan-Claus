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
        if(CheckRequirements())
        {
            Debug.Log("You can talk to me now");
        }
        else
        {
            Debug.Log("You can't talk to me yet");
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
}
