using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Container
{
    [SerializeField] CupInfo cupInfo;
    private void Start() {
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);
    }

    void OnStateEnter(GameState state)
    {
        if (state == GameState.Cafe)
        {
            gameObject.SetActive(true);
        }
    }

    void OnStateExit(GameState state)
    {
        if (state == GameState.Cooking)
        {
            cupInfo.numberOfDrops = numberOfDrops;
        }
    }
}
