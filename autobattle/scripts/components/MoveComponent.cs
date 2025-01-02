// this kind of REQUIRES a CharacterBody2D node to call moveComponent.Move(this) 
// in their physics process. whoops? i guess i can work with that
using Godot;
using System;

[GlobalClass]
public partial class MoveComponent : Node
{
	[Export] public float Speed = 50.0f;
	
	private Vector2 Velocity;
	
	public void LerpToward(Vector2 velocity, float acceleration)
	{
		Velocity = Velocity.Lerp(velocity, acceleration);
	}
	
	public void SetVelocity(Vector2 velocity)
	{
		Velocity = velocity;
	}
	
	public void SetVelocityX(float x)
	{
		Velocity.X = x;
	}
	public void SetVelocityY(float y)
	{
		Velocity.Y = y;
	}
	
	public Vector2 GetVelocity()
	{
		return Velocity;
	}

	public void SetDirection(Vector2 from, Vector2 to)
	{
		Velocity = to - from;
		Velocity = Velocity.Normalized();
	}
	
	public void Move(CharacterBody2D characterBody) 
	{	
		characterBody.Velocity = Velocity * Speed;
		characterBody.MoveAndSlide();
	}
}
