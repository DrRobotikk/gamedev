using Godot;

public abstract partial class PlayerState : CharacterState
{
    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GameGonstants.INPUT_ATTACK))
        {
            characterNode.StateMachineNode.SwitchState<PlayerAttackState>();
        }
    }

}