using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;

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
        rightHandMovement.moving = context.performed;
    }
}
