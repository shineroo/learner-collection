// THIS STATE IS EXCLUSIVE TO THE PLAYER CHARACTER!!!

using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class DashAttackState : State
{
	[Export] public double dashLength = 0.15;
	[Export] public float dashSpeed = 1500;
	private double currentDashTime = 0;
	private Vector2 dashDirection;
	private Vector2 dashVector;

	public override void Enter()
    {
        currentDashTime = 0;
		
		Vector2 mousePos = Vector2.Zero;
		if (entity is Player player)
		{
			mousePos = player.GetMouse();
			dashDirection = mousePos.Normalized();
		}
		dashVector = dashDirection * dashSpeed;
		
		double dashStrength = Math.Clamp(mousePos.Length(), 30, 180);
		double dashLengthModifier = Remap((float)dashStrength, 30, 180, 0.06f, 0);
		currentDashTime += dashLengthModifier;

		move.SetVelocityVector(dashDirection);
		move.Move(entity);
		EnableHitbox();
    }

	private float Remap(float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

    public override void PhysicsUpdate(double delta)
    {
		currentDashTime += delta;
		move.SetVelocityVector(dashVector);
		if (currentDashTime >= dashLength)
        	stateMachine.ForceTransitionTo("Fall");	
    }

    public override void Exit()
    {
		DisableHitbox();
        move.SetVelocityVector(Vector2.Zero);
		//move.SetVelocityY(-0.8f);
    }

    public void EnableHitbox()
    {
        stateMachine.SendEnableHitbox(this.Name);
    }

    public void DisableHitbox()
    {
        stateMachine.SendDisableHitbox(this.Name);
    }
}
