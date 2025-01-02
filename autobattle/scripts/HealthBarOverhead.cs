using Godot;
using System;

public partial class HealthBarOverhead : TextureProgressBar
{
	[Export] public Health health;

    public override void _Ready()
    {
        MaxValue = health.maxHealth;
		Value = health.currentHealth;
		Visible = false;

		health.Connect("HealthChanged", Callable.From((float damage) => UpdateBarValue()));
		health.Connect("MaxHealthChanged", Callable.From((float newValue) => UpdateMaxHealth(newValue)));
    }

    public void ShowBar()
	{
		Visible = true;
	}

	// ! this needs damage because its connected to the Damaged signal (which should be renamed to OnDamaged honestly)
	private void UpdateBarValue()
	{
		Value = health.currentHealth;
		ShowBar();
	}

	private void UpdateMaxHealth(float newValue)
	{
		MaxValue = newValue;
	}
}
