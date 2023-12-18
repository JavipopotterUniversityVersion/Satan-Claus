using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(HandMovement))]
[RequireComponent(typeof(ClientDialogHandler))]
public class ClientBehaviour : MonoBehaviour
{
    Vector2 targetPosition;
    Vector2 originalPosition;
    [SerializeField] GameObject rubbish;
    HandMovement handMovement;
    AnimationManager an;
    Collider2D col;
    bool isServed = false;

    private void Awake() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("target");
        targetPosition = objects[UnityEngine.Random.Range(0, objects.Length)].transform.position;

        col = GetComponent<Collider2D>();
        an = GetComponent<AnimationManager>();
        handMovement = GetComponent<HandMovement>();

        col.enabled = false;
    }

    private void OnEnable() {
        originalPosition = transform.position;
        DialoguesManager.dialoguesManager.servedEvent.AddListener(LeaveRubbish);

        isServed = false;
        handMovement.Move(MathF.Sign(targetPosition.x - transform.position.x));
    }

    private void Update() {
        if(Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f && !isServed && (Vector2)transform.position != targetPosition )
        {
            transform.position = targetPosition;
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
        Instantiate(rubbish, targetPosition, Quaternion.identity);
        handMovement.Move(1);
    }
}
