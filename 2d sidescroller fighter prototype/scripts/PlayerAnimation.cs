using Godot;
using System;

public partial class PlayerAnimation : Sprite2D
{
	[Export]
	private AnimationPlayer _animationPlayer;
	
	private bool _facingRight = true;
	
	[Signal]
	public delegate void AnimationFinishedEventHandler(string key);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationPlayer = GetNode("AnimationPlayer") as AnimationPlayer;
		_animationPlayer.Play("Idle");
	}
	
	private void _on_state_component_changed_state(string key)
	{
		_animationPlayer.Stop(true);
		_animationPlayer.Play(key);
	}

	private void _on_animation_player_animation_finished(string key)
	{
		EmitSignal(SignalName.AnimationFinished, _animationPlayer.CurrentAnimation);
	}
}








