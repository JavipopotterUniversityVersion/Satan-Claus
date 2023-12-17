using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CafeTableDestroyer : MonoBehaviour
{
    private bool canHit;
    private int tableState;
    [SerializeField] Sprite[] tableDestruction;
    [SerializeField] SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bat") && collision.attachedRigidbody.angularVelocity > 5 && canHit)
        {
            canHit = false;
            tableState++;
            DestroyTable();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Bat"))
        {
            canHit = true;
        }
    }
    private void DestroyTable()
    {
        if (tableState == 6)
        {
            OnTableDestroyed?.Invoke();
        }
        else
        {
            sr.sprite = tableDestruction[tableState];
        }
    }
    UnityEvent OnTableDestroyed;
}
