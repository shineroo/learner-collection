using Godot;
using System;

public partial class RunState : State
{
    public override void PhysicsUpdate(double delta)
    {
        float inputDirection = entity.GetInputDirection();
		if (inputDirection != 0)
		{
			move.SetVelocityX(inputDirection);
		}
		else
		{
			stateMachine.TransitionTo("Idle");
		}

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
