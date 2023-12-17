using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private HandMovement leftHandMovement;
    [SerializeField] private RightHandMovement rightHandMovement;
    PlayerInput playerInput;
    private InteractionHandler interactionHandler;
    bool canMove = true;

    private void Start() {
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);

        interactionHandler = GetComponent<InteractionHandler>();

        playerInput = GetComponent<PlayerInput>();
    }


    void OnStateExit(GameState state)
    {
        if(state != GameState.Cafe)
        {
            canMove = true;
        }
    }
    void OnStateEnter(GameState state)
    {
        if(state != GameState.Cafe)
        {
            canMove = false;
        }
    }

    public void LeftHandMovement(InputAction.CallbackContext context)
    {
        if(!canMove) return;

        leftHandMovement.Move(context.ReadValue<Vector2>().x);
    }
    public void RightHandMovement(InputAction.CallbackContext context)
    {
        if(!canMove) return;

        if(context.performed)
        {
            rightHandMovement.moving = true;
        }
        else if(context.canceled || Drageable.drageable.m_TargetJoint != null)
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
}
