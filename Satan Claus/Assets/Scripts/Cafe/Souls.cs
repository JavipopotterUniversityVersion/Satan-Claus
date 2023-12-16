using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent(out Drop drop))
        {
            drop.type = TypeOfDrop.souls;
        }
    }
}
