using Godot;

public abstract partial class EnemyState : CharacterState{
    protected Vector3 destination;
    protected Vector3 GetPointGlobalPosisition(int index)
    {
        Vector3 localPosition = characterNode.PathNode.Curve.GetPointPosition(index);
        Vector3 globalPosition = characterNode.PathNode.GlobalPosition;

        return localPosition + globalPosition;
    }

    protected void HandleChaseAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
    }

    protected void Move()
    {
        characterNode.AgentNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);

        characterNode.MoveAndSlide();
        characterNode.Flip();
    }
    
}