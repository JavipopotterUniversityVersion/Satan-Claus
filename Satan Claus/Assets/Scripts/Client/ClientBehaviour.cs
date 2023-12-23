using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(HandMovement))]
[RequireComponent(typeof(ClientDialogHandler))]
public class ClientBehaviour : MonoBehaviour
{
    Transform targetPosition;
    Vector2 originalPosition;
    HandMovement handMovement;
    AnimationManager an;
    Collider2D col;
    bool isServed = false;
    StateChangerInteractable table;

    private void Awake() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("target");
        table = GameObject.FindGameObjectWithTag("table").GetComponent<StateChangerInteractable>();
        targetPosition = objects[UnityEngine.Random.Range(0, objects.Length)].transform;

        col = GetComponent<Collider2D>();
        an = GetComponent<AnimationManager>();
        handMovement = GetComponent<HandMovement>();

        col.enabled = false;
    }

    private void OnEnable() {
        originalPosition = transform.position;
        DialoguesManager.dialoguesManager.servedEvent.AddListener(LeaveRubbish);

        isServed = false;
        handMovement.Move(MathF.Sign(targetPosition.position.x - transform.position.x));
    }

    private void Update() {
        if(Mathf.Abs(transform.position.x - targetPosition.position.x) < 0.1f && !isServed && transform.position != targetPosition.position )
        {
            transform.position = targetPosition.position;
            handMovement.Move(0);
            an.Sit(true);
            col.enabled = true;
        }

        if(isServed && Mathf.Abs(transform.position.x - originalPosition.x) < 0.1f)
        {
            an.Sit(false);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable() {
        DialoguesManager.dialoguesManager.servedEvent.RemoveListener(LeaveRubbish);
    }

    public void LeaveRubbish()
    {
        an.Sit(true);
        isServed = true;
        col.enabled = false;
        table.gameObject.SetActive(true);
        table.transform.position = targetPosition.position;
        handMovement.Move(1);
    }
}
