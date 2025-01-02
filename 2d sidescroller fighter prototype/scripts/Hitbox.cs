using Godot;
using System;

public partial class Hitbox : CollisionShape2D
{
	[Export] public int damage = 0;
	[Export] public Vector2 knockback = new Vector2(0, 0);
	[Export] public float stun = 0f; 
	public override void _Ready()
	{
		this.Disabled = true;
	}
}
