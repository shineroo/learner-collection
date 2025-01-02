using Godot;
using System;

public partial class State : Node
{
	[Export] public bool interruptable = true;
	public StateComponent stateMachine;
	public EntityComponent entity;
	public MoveComponent move;
	
	public virtual void Enter() { return;}
	public virtual void Exit() { return;}
	
	public virtual void StateReady() { return;}
	public virtual void Update(double delta) { return;}
	public virtual void PhysicsUpdate(double delta) { return;}
	public virtual void HandleInput(InputEvent @event) { return;}
}
