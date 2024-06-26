using System;
using System.Linq;
using System.Reflection.Metadata;
using Godot;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode{ get; private set;}
    [Export] public Sprite3D SpirtePlayerNode{ get; private set;}
    [Export] public StateMachine StateMachineNode{ get; private set;}
    [Export] public Area3D HurtBoxNode {get; private set;}

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode {get;private set;}
    [Export] public NavigationAgent3D AgentNode {get; private set;}
    [Export] public Area3D ChaseAreaNode {get; private set;}
    [Export] public Area3D AttackAreaNode {get; private set;}

    public Vector2 direction = new();

    public override void _Ready()
    {
        HurtBoxNode.AreaEntered += HandleHurtBoxEntered;
    }

    private void HandleHurtBoxEntered(Area3D area)
    {
        StatResource health = GetStatResource(Stat.Health);

        GD.Print(health.StatValue);
    }

    public StatResource GetStatResource(Stat stat)
    {
        return stats.Where((element) => element.statType == stat).FirstOrDefault();
    }

    public void Flip(){
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0;
        SpirtePlayerNode.FlipH = isMovingLeft;
    }
}