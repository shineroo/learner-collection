using Godot;
using System;
using System.Collections.Generic;

public partial class AttackComponent : Node2D
{
	[Export] private EntityComponent entity;
	private Dictionary<string, Hitbox> _attacks;

	public int damage = 0;
	public Vector2 knockback = new Vector2(0, 0);
	public float stun = 0f;
	public string attackName = "AirSpin";

	private bool disabled = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_attacks = new Dictionary<string, Hitbox>();
		foreach (Node node in GetChildren())
		{
			if (node is Hitbox attack)
			{
				_attacks[node.Name] = attack;				
			}
		}
	}

    public override void _PhysicsProcess(double delta)
    {
		_attacks[attackName].Disabled = disabled;
    }

	private void _on_state_component_enable_hitbox(string attack)
	{
		SetAttackParams(attack);
		disabled = false;		
	}

	private void _on_state_component_disable_hitbox(string attack)
	{
		disabled = true;
	}

	private void SetAttackParams(string attack)
	{
		damage = _attacks[attack].damage;
		knockback = _attacks[attack].knockback;
		if (!entity._facingRight)
		{
			knockback.X = knockback.X * -1;
		}		
		stun = _attacks[attack].stun;
		_attacks[attackName].Disabled = true;
		attackName = attack;
	}
}
