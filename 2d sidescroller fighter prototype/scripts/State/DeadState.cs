using Godot;
using System;

public partial class DeadState : State
{
	private bool animationFinished = false;

  public override void Enter()
  {
    entity.alive = false;
  }

  public override void PhysicsUpdate(double delta)
  {
    move.LerpVelocityX(0, 0.15f);
  }
}
