using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    MainMenu,
    Paused,
    Cafe,
    Dialog,
    Cooking,
    Cleaning,
    stateHolder,
    End
}

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    GameState _stateHolder;
    GameState stateHolder
    {
        get { return _stateHolder; }
        set
        {
            if(value == GameState.stateHolder)
            {
                _stateHolder = GameState.Cafe;
                print("You can't set the stateHolder to stateHolder");
            }
            else
            {
                _stateHolder = value;
            }
        }
    }
    GameState gameState;
    public GameState newState;
    [HideInInspector] public UnityEvent<GameState> OnStateEnter;
    [HideInInspector] public UnityEvent<GameState> OnStateExit;

    private void Awake() {
        GM = this;
        Screen.SetResolution(1920, 1080, true);
        OnStateEnter = new UnityEvent<GameState>();
        OnStateExit = new UnityEvent<GameState>();
    }

    public void ChangeStateOfGame(GameState newState)
    {
        this.newState = newState;

        OnStateExit?.Invoke(gameState);

        switch(newState)
        {
            case GameState.stateHolder:
                ChangeStateOfGame(stateHolder);
                break;
            case GameState.End:
                DialoguesManager.dialoguesManager.ExecuteDialogViaKey("End");
                break;
        }

        OnStateEnter?.Invoke(newState);

        stateHolder = gameState;
        gameState = newState;
    }
}