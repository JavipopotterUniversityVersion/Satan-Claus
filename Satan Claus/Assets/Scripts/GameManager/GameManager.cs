using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    MainMenu,
    Cafe,
    Dialog,
    Cooking,
    Cleaning,
    stateHolder
}

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    GameState stateHolder;
    GameState gameState;
    [HideInInspector] public UnityEvent<GameState> OnStateEnter;
    [HideInInspector] public UnityEvent<GameState> OnStateExit;

    private void Awake() {
        GM = this;
    }

    public void ChangeStateOfGame(GameState newState)
    {
        OnStateExit?.Invoke(gameState);

        switch(newState)
        {
            case GameState.stateHolder:
                ChangeStateOfGame(stateHolder);
                break;
        }

        OnStateEnter?.Invoke(newState);

        stateHolder = gameState;
        gameState = newState;
    }
}