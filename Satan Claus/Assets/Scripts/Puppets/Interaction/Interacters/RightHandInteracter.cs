using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandInteracter : InteractionManager
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out StateChangerInteractable clientDialog))
        {   
            DetectInteractable(clientDialog);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.TryGetComponent(out StateChangerInteractable clientDialog))
        {
            StopDetectingInteractable();
        }
    }
}
