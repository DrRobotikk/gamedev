using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();

        destination = GetPointGlobalPosisition(0);
    }
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameGonstants.ANIM_MOVE);

        characterNode.AgentNode.TargetPosition = destination;

        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }

    protected override void ExitState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.AgentNode.IsNavigationFinished())
        {
            characterNode.StateMachineNode.SwitchState<EnemyPatrolState>();
            return;
        }
        Move();

        
    }

}
