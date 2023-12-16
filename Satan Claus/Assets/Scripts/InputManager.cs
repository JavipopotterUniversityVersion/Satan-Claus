using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private HandMovement leftHandMovement;
    [SerializeField] private RightHandMovement rightHandMovement;
    [SerializeField] private InteractionHandler interactionHandler;
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
