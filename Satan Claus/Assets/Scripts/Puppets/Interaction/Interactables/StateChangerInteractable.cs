using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangerInteractable : MonoBehaviour, IInteractable
{
    public Transform myTransform => transform;
    [SerializeField] GameState stateToChangeTo;
    
    public void Interact()
    {
        GameManager.GM.ChangeStateOfGame(stateToChangeTo);
    }
}
