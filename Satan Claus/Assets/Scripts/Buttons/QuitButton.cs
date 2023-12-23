using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : CustomButton
{
    public override void OnClick()
    {
        Application.Quit();
    }
}
