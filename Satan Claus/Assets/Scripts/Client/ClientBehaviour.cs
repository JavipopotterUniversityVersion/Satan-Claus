using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(HandMovement))]
public class ClientBehaviour : MonoBehaviour
{
    Vector2 targetPosition;
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
        DialoguesManager.dialoguesManager.servedEvent.AddListener(LeaveRubbish);

        isServed = false;
        handMovement.Move(MathF.Sign(targetPosition.x - transform.position.x));
    }

    private void Update() {
        if(Vector2.Distance(transform.position, targetPosition) < 0.1f && !isServed && (Vector2)transform.position != targetPosition )
        {
            transform.position = targetPosition;
            handMovement.Move(0);
            an.Sit(false);
            col.enabled = true;
        }
    }

    private void OnDisable() {
        DialoguesManager.dialoguesManager.servedEvent.RemoveListener(LeaveRubbish);
    }

    public void LeaveRubbish()
    {
        isServed = true;
        col.enabled = false;
        Instantiate(rubbish, targetPosition, Quaternion.identity);
        handMovement.Move(1);
    }
}
