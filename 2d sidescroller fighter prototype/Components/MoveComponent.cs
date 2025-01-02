// this kind of REQUIRES a CharacterBody2D node to call moveComponent.Move(this) 
// in their physics process. whoops? i guess i can work with that
using Godot;
using System;

[GlobalClass]
public partial class MoveComponent : Node
{
	[Export] public bool _hasGravity = true;
	[Export] public float _speed = 300.0f;
	[Export] public float _jumpVelocity = -400.0f;
	[Export] public float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
	private Vector2 Velocity;
	
	public void LerpToward(Vector2 velocity, float acceleration)
	{
		Velocity = Velocity.Lerp(velocity * _speed, acceleration);
	}
	
	public void SetVelocityVector(Vector2 velocity)
	{
		Velocity = velocity;
	}
	
	public void SetVelocityX(float x)
	{
		Velocity.X = x * _speed;
	}
	
	public void LerpVelocityX(float x, float acceleration)
	{
		Velocity.X = Velocity.X + (x - Velocity.X) * acceleration;
	}
	
	public void SetVelocityY(float y)
	{
		Velocity.Y = y * _speed;
	}
	
	public void Jump()
	{
		Velocity.Y = _jumpVelocity;
	}	
	
	public void ApplyGravity(double delta)
	{
		if (_hasGravity)
			Velocity.Y += _gravity * (float)delta;
	}
	
	public Vector2 GetVelocity()
	{
		return Velocity;
	}
	
	public void Move(CharacterBody2D characterBody) 
	{	
		characterBody.Velocity = Velocity;
		characterBody.MoveAndSlide();
	}
}
