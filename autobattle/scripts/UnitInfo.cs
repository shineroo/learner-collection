using Godot;
using System;

public partial class UnitInfo : RichTextLabel
{
	[Export] public Entity entity;
	[Export] public RichTextLabel TextLabel;
	[Export] public Button button;

    public override void _Ready()
    {
        base._Ready();
		TextLabel.Text = $"HP: {entity.Health.currentHealth}/{entity.Stats.MaxHP} \n gay ass bitch";
    }

	public override void _Process(double delta)
	{
		TextLabel.Text = $"HP: {entity.Health.currentHealth}/{entity.Stats.MaxHP} \n gay ass bitch";
	}

	public void _on_button_pressed()
	{
		TextLabel.Text = $"HP: {entity.Health.currentHealth}/{entity.Stats.MaxHP} \n gay ass bitch";
	}
}
