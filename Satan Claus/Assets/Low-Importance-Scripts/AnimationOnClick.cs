using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnClick : AnimationOnMouseHover
{
    public override void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
            base.OnMouseOver();
    }
}
