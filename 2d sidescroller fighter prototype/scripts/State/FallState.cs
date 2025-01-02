using Godot;
using System;

public partial class FallState : State
{
    public override void PhysicsUpdate(double delta)
    {
		float inputDirection = entity.GetInputDirection();
		move.SetVelocityX(inputDirection);

		if (entity.IsOnFloor())
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
