using Godot;
using System;

public partial class AnimationPlayer : Godot.AnimationPlayer
{
	private int direction = 0; // 0 - down, 1 - left, 2 - up, 3 - right
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CurrentAnimation = "idle_down";
	}

	public virtual void PlayAnimation(Vector2 velocity)
	{
		if (velocity == Vector2.Zero)
		{
			switch (direction)
			{
				case 0:
					ChangeAnimation("idle_down");
					break;
				case 1: 
					ChangeAnimation("idle_left");
					break;
				case 2:
					ChangeAnimation("idle_up");
					break;
				case 3:
					ChangeAnimation("idle_right");
					break;
			}			
			return;
		}

		float angle = radToDeg(velocity.Angle());
		if (angle > 45 && angle < 135)
		{
			ChangeAnimation("walk_down");
			direction = 0;
		}
		if (angle < -135 || angle > 135)
		{
			ChangeAnimation("walk_left");
			direction = 1;
		}
		if (angle < -45 && angle > -135)
		{
			ChangeAnimation("walk_up");
			direction = 2;
		}
		if (angle > -45 && angle < 45)
		{
			ChangeAnimation("walk_right");
			direction = 3;
		}
	}

	public void ChangeAnimation(string animation)
	{
		if (CurrentAnimation != animation)
		{
			CurrentAnimation = animation;
		}
	}

	public float radToDeg(float rad)
	{
		return 180 / (float)Math.PI * rad;
	}
}
