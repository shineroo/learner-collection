using Godot;
using System;

public partial class IdleState : State
{	
    public override void PhysicsUpdate(double delta)
    {
		// logic
        float inputDirection = entity.GetInputDirection();
		if (inputDirection == 0)
		{
			move.LerpVelocityX(0, 0.3f);
		}
		else
		{
			stateMachine.TransitionTo("Run");
		}

		// transitions
		if (entity.GetJump())
		{
			stateMachine.TransitionTo("Jump");
		}
		if (move.GetVelocity().Y > 0 && !entity.IsOnFloor())
		{
			stateMachine.TransitionTo("Fall");
		}
		if (entity.GetAttack())
		{
			stateMachine.TransitionTo("Attack1");
		}
		if (entity.GetDash())
		{
			stateMachine.TransitionTo("Dash");
		}		
    }
}
