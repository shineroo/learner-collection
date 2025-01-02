using Godot;
using System;

public partial class HitStunState : State
{
	public int damage = 0;
	public Vector2 knockback = new Vector2(0, 0);
	public float stun = 0f;

	private float _currentStun = 0f;

    public override void Enter()
    {
		_currentStun = 0;
		move.SetVelocityVector(knockback);
		move.Move(entity);
    }

    public override void PhysicsUpdate(double delta)
    {
        _currentStun += (float)delta;
		move.LerpVelocityX(0, 0.15f);

		if (_currentStun >= stun)
		{
			GD.Print("back to idle");
			stateMachine.TransitionTo("Idle");
		}
    }
}
