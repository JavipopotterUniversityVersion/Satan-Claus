using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private HandMovement leftHandMovement;
    [SerializeField] private RightHandMovement rightHandMovement;
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
        else if(context.canceled)
        {
             print("RightHandMovement'nt");
            rightHandMovement.moving = false;
        }
    }
}
