using Godot;
using System;

[GlobalClass]
public partial class HurtboxComponent : Area2D
{
	[Signal] public delegate void DamagedEventHandler(int damage, Vector2 knockback, float stun);

	Random random = new Random();

	private void _on_area_entered(AttackComponent area)
	{
		Vector2 knockback = area.knockback;
		
		double minValue = 0.7;
        double maxValue = 1.3;

        double randomValue = (random.NextDouble() * (maxValue - minValue)) + minValue;
		knockback.X = knockback.X * (float)randomValue;

		EmitSignal(SignalName.Damaged, area.damage, knockback, area.stun);
	}
}
