using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private HandMovement leftHandMovement;
    [SerializeField] private RightHandMovement rightHandMovement;
    private InteractionHandler interactionHandler;
    PlayerInput playerInput;
    Drageable drageable;
    bool _canMove = true;
    bool canMove
    {
        get { return _canMove; }
        set
        {
            if(!value)
            {
                leftHandMovement.Move(0);
                rightHandMovement.moving = false;
            }
            _canMove = value;
        }
    }

    private void Start() {
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);

        playerInput = GetComponent<PlayerInput>();

        interactionHandler = GetComponent<InteractionHandler>();
        drageable = GetComponent<Drageable>();

        drageable.OnDrag.AddListener(OnDrag);
    }

    private void OnDisable() {
        GameManager.GM.OnStateEnter.RemoveListener(OnStateEnter);
        GameManager.GM.OnStateExit.RemoveListener(OnStateExit);

        drageable.OnDrag.RemoveListener(OnDrag);
    }

    void OnDrag(bool value)
    {
        canMove = !value;
    }

    void OnStateExit(GameState state)
    {
        if(state != GameState.Cafe)
        {
            playerInput.SwitchCurrentActionMap("Playing");
        }
    }
    void OnStateEnter(GameState state)
    {
        if(state != GameState.Cafe)
        {
            playerInput.SwitchCurrentActionMap("Paused");
        }
    }

    public void LeftHandMovement(InputAction.CallbackContext context)
    {
        leftHandMovement.Move(context.ReadValue<Vector2>().x);
    }
    public void RightHandMovement(InputAction.CallbackContext context)
    {
        if(!canMove) return;

        if(context.performed)
        {
            rightHandMovement.moving = true;
        }
        else if(context.canceled)
        {
            rightHandMovement.moving = false;
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactionHandler.Interact();
        }
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(GameManager.GM.newState == GameState.Paused)
            {
                GameManager.GM.ChangeStateOfGame(GameState.Cafe);
            }
            else
            {
                GameManager.GM.ChangeStateOfGame(GameState.Paused);
            }
        }
    }
}
