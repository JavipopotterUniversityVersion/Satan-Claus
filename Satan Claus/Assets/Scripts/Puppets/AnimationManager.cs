using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    string[] PARAMETERS_NAME = new string[3] { "moving", "opened", "sit" };

    [SerializeField] Animator an;

    void Awake()
    {
        an = GetComponent<Animator>();
    }

    public void Move(bool value)
    {
        an.SetBool(PARAMETERS_NAME[0], value);
    }

    public void OpenMouth(bool value)
    {
        an.SetBool(PARAMETERS_NAME[1], value);
    }

    public void Sit(bool value)
    {
        an.SetBool(PARAMETERS_NAME[2], value);
    }
}
