using Godot;
using System;

public partial class Player : Character
{
    
    

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(GameGonstants.INPUT_MOVE_LEFT,GameGonstants.INPUT_MOVE_RIGHT,GameGonstants.INPUT_MOVE_FORWARD,GameGonstants.INPUT_MOVE_BACKWARD);
    
    }

    
}
