using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private HandMovement handMovement;
    public void LeftHandMovement(InputAction.CallbackContext context)
    {
        handMovement.Move(context.ReadValue<int>());
        Debug.Log("AAAA");
    }

}
