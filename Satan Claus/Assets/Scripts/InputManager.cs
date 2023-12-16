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
    [SerializeField] private HandMovement handMovement;
    public void LeftHandMovement(InputAction.CallbackContext context)
    {
        handMovement.Move(context.ReadValue<Vector2>().x);
    }

}
