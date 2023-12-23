using UnityEngine;

public class AnimationOnMouseHover : AnimationOnEvent
{
    public virtual void OnMouseOver()
    {
        PlayAnimation();
    }
}
