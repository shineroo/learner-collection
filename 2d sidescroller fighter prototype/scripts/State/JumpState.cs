using Godot;
using System;

public partial class JumpState : State
{
	double timer = 0.3;
	
	public override void Enter() 
	{
		move.Jump();
	}

    public override void PhysicsUpdate(double delta)
    {
		timer -= delta;

		float inputDirection = entity.GetInputDirection();
		move.SetVelocityX(inputDirection);


		if (move.GetVelocity().Y >= 0 && !entity.IsOnFloor())
		{
			stateMachine.TransitionTo("Fall");
		}
		if(entity.IsOnFloor())
		{
			stateMachine.TransitionTo("Idle");
		}
		if (entity.GetJump())
		{
			stateMachine.TransitionTo("Jump");
		}
		if(entity.GetAttack())
		{
			stateMachine.TransitionTo("AirSpin");
		}
		if (entity.GetDash())
		{
			stateMachine.TransitionTo("Dash");
		}

    }
}
