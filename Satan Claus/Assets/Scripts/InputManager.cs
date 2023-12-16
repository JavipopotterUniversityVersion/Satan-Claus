using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private HandMovement leftHandMovement;
    [SerializeField] private RightHandMovement rightHandMovement;
    private PlayerInput playerInput;
    private Drageable drageable;
    [SerializeField] private InteractionHandler interactionHandler;

    private void Awake() {
        GameManager.GM.OnStateEnter.AddListener(OnStateEnter);
        GameManager.GM.OnStateExit.AddListener(OnStateExit);

        playerInput = GetComponent<PlayerInput>();
        drageable = GetComponent<Drageable>();
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
        if(context.canceled || drageable.m_TargetJoint != null)
        {
            print("RightHandMovement'nt");
            rightHandMovement.moving = false;
        }
        else if(context.performed)
        {
            print("RightHandMovement");
            rightHandMovement.moving = true;
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
