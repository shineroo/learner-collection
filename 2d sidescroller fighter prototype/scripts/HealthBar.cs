using Godot;
using System;

public partial class HealthBar : TextureProgressBar
{
	[Export] private HealthComponent health;


	public override void _Ready()
	{
		this.MaxValue = health.maxHealth;
		this.Value = health.currentHealth;
	}

    public override void _Process(double delta)
    {
        this.Value = health.currentHealth;
    }
}
