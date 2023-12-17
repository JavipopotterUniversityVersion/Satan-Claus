using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackManager : MonoBehaviour
{
    LeftHandInteracter _leftHandInteracter;
    RightHandInteracter _rightHandInteracter;
    [SerializeField] GameObject[] feedBackButtons;

    public void Start()
    {
        _leftHandInteracter = FindObjectOfType<LeftHandInteracter>();
        _leftHandInteracter.CanInteract.AddListener(OnCanTalk);
        _leftHandInteracter.CantInteract.AddListener((IInteractable interactable) => feedBackButtons[0].SetActive(false));

        _rightHandInteracter = FindObjectOfType<RightHandInteracter>();
        _rightHandInteracter.CanInteract.AddListener(OnCanCook);
        _rightHandInteracter.CantInteract.AddListener((IInteractable interactable) => feedBackButtons[1].SetActive(false));
    }

    void OnCanTalk(IInteractable interactable)
    {
        feedBackButtons[0].SetActive(true);
        feedBackButtons[0].transform.position = new Vector2(interactable.myTransform.position.x, interactable.myTransform.position.y + 1.5f);
    }

    void OnCanCook(IInteractable interactable)
    {
        feedBackButtons[1].SetActive(true);
        feedBackButtons[1].transform.position = new Vector2(interactable.myTransform.position.x, interactable.myTransform.position.y + 1.5f);
    }
}