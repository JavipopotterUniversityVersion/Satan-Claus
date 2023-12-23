using UnityEngine;

public class StateChangerButton : CustomButton
{
    [SerializeField] GameState state;
    public override void OnClick()
    {
        GameManager.GM.ChangeStateOfGame(state);
    }
}
