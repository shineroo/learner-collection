using Godot;
using System;

[GlobalClass]
public partial class EntityComponent : Godot.CharacterBody2D
{
	[Export] public int maxAirJumps = 1;
	public int jumpsAvailable = 1;

	public bool _facingRight = true;
	public bool alive = true;

	public virtual float GetInputDirection()
	{
		return 0f;
	}

	public virtual bool GetAttack() {return false;}
	public virtual bool GetSpecialAttack() {return false;}
	public virtual bool GetJump() {return false;}
	public virtual bool GetDash() {return false;}
}
