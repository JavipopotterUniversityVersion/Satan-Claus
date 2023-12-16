using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private HandMovement leftHandMovement;
    [SerializeField] private RightHandMovement rightHandMovement;
    PlayerInput playerInput;
    [SerializeField] private InteractionHandler interactionHandler;

    private void Awake() {
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);

        playerInput = GetComponent<PlayerInput>();
    }


    void OnStateExit(GameState state)
    {
        if(state != GameState.Cafe)
        {
            // playerInput.enabled = true;
        }
    }
    void OnStateEnter(GameState state)
    {
        if(state != GameState.Cafe)
        {
            // playerInput.enabled = false;
        }
    }

    public void LeftHandMovement(InputAction.CallbackContext context)
    {
        leftHandMovement.Move(context.ReadValue<Vector2>().x);
    }
    public void RightHandMovement(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            print("RightHandMovement");
            rightHandMovement.moving = true;
        }
        else if(context.canceled || Drageable.drageable.m_TargetJoint != null)
        {
             print("RightHandMovement'nt");
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
