using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class StateComponent : Node
{
	// im out of clever ideas
	[Export] public NodePath initialState;
	[Export] private EntityComponent _entityComponent;
	[Export] private MoveComponent _moveComponent;
	
	private Dictionary<string, State> _states;
	public State _currentState;
	
	[Signal] public delegate void ChangedStateEventHandler(string key);
	[Signal] public delegate void EnableHitboxEventHandler(string attack);
	[Signal] public delegate void DisableHitboxEventHandler(string attack);
	
	public override void _Ready()
	{
		_states = new Dictionary<string, State>();
		foreach (Node node in GetChildren()) {
			if (node is State s) {
				_states[node.Name] = s;

				s.entity = _entityComponent;
				s.move = _moveComponent;				
				s.stateMachine = this;
			}
		}		
		_currentState = GetNode<State>(initialState);
		_currentState.Enter();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_currentState.Update(delta);
		_moveComponent.Move(_entityComponent);
	}
	
	public override void _PhysicsProcess(double delta)
	{
		_moveComponent.ApplyGravity(delta);
		if (_entityComponent.IsOnFloor() && _moveComponent.GetVelocity().Y >= 0)
		{
			_moveComponent.SetVelocityY(0f);
		}
		if (_entityComponent.IsOnCeiling() && _moveComponent.GetVelocity().Y < 0)
		{
			_moveComponent.SetVelocityY(0f);
		}

		_currentState.PhysicsUpdate(delta);
		
	}

	public void SendEnableHitbox(string attack)
	{
		EmitSignal(SignalName.EnableHitbox, attack);
	}

	public void SendDisableHitbox(string attack)
	{
		EmitSignal(SignalName.DisableHitbox, attack);
	}
	
	public void TransitionTo(string key) {
		if(!_states.ContainsKey(key) || !_currentState.interruptable)
		{
			return;
		}			
		GD.Print(key);
		_currentState.Exit();
		_currentState = _states[key];
		_currentState.Enter();
		EmitSignal(SignalName.ChangedState, key);
	}

	public void ForceTransitionTo(string key) {
		if(!_states.ContainsKey(key))
		{
			return;
		}			
		
		_currentState.Exit();
		_currentState = _states[key];
		_currentState.Enter();
		EmitSignal(SignalName.ChangedState, key);
	}

	private void _on_hurtbox_component_damaged(int damage, Vector2 knockback, float stun)
	{
		if(!_states.ContainsKey("HitStun"))
			return;

		if (_states["HitStun"] is HitStunState hitStun)
		{
			hitStun.stun = stun;
			hitStun.damage = damage;
			hitStun.knockback = knockback;
		}
		TransitionTo("HitStun");
	}

	private void _on_health_component_no_health()
	{
		if(!_states.ContainsKey("Dead"))
			return;
		TransitionTo("Dead");
	}
}
