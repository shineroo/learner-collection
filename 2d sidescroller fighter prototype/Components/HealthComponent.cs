using Godot;
using System;

[GlobalClass]
public partial class HealthComponent : Node
{
	[Export] public int maxHealth = 10;
	public int currentHealth;

	[Signal] public delegate void NoHealthEventHandler();

    public override void _Ready()
    {
        currentHealth = maxHealth;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (currentHealth <= 0)
		{
			EmitSignal(SignalName.NoHealth);
		}
    }

	private void _on_hurtbox_component_damaged(int damage, Vector2 knockback, float stun)
	{
		currentHealth = currentHealth - damage;
	}
}
