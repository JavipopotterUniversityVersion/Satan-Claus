using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackManager : MonoBehaviour
{
    private LeftHandInteracter _leftHandInteracter;

    public void Start()
    {
        _leftHandInteracter = FindObjectOfType<LeftHandInteracter>();
        _leftHandInteracter.CanInteract.AddListener(OnCanTalk);
    }

    public void OnCanTalk(Vector2 position)
    {
        // Show interaction button
    }
}