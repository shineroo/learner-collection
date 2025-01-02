using Godot;
using System;

[GlobalClass]
public partial class Health : Node
{
	[Export] public float maxHealth;
	public float currentHealth;

	[Signal] public delegate void HealthChangedEventHandler(float damage);
	[Signal] public delegate void MaxHealthChangedEventHandler(float newValue);

    public override void _Ready()
    {
		// this doesnt really do anything
        currentHealth = maxHealth;
    }

	
	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
		EmitSignal(SignalName.HealthChanged, currentHealth);
	}

	public void HealDamage(float heal)
	{
		currentHealth += heal;
		if (currentHealth > maxHealth) 
		{
			currentHealth = maxHealth;
		}
		EmitSignal(SignalName.HealthChanged, currentHealth);
	}

	// returns a floating point number from 1 to 0
	public float GetHealthPercent()
	{
		return currentHealth / maxHealth;
	}

	// todo: seperate the healing to max health part into a different function please. (and dont forget the entity Ready() function)
	public void SetMaxHP(float health)
	{
		maxHealth = health;
		EmitSignal(SignalName.MaxHealthChanged, health);
	}

	public void Die()
	{
		QueueFree();
	}
}
