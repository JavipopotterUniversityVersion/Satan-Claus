using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandInteracter : InteractionManager
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (TryGetComponent(out ClientDialogHandler clientDialog))
        {
            DetectInteractable(clientDialog);
        }
    }
}