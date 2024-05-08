using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animPlayerNode;
    [Export] public Sprite3D spirtePlayerNode;
    [Export] public StateMachine stateMachineNode;
    public Vector2 direction = new();


    public override void _Ready()
    {
       
    }
   

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(GameGonstants.INPUT_MOVE_LEFT,GameGonstants.INPUT_MOVE_RIGHT,GameGonstants.INPUT_MOVE_FORWARD,GameGonstants.INPUT_MOVE_BACKWARD);
        
        
    }

    public void Flip(){
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
        {
            return;
        }


        bool isMovingLeft = Velocity.X < 0;
        spirtePlayerNode.FlipH = isMovingLeft;
    }
}
