using Godot;
using System;
using System.Collections.Generic;

public partial class ClosableMenu : Control
{
	public List<SubmenuWindow> SubmenuWindows;
	public bool visible = true;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ToggleMenu()
	{
		visible = !visible;
		this.Visible = visible;
	}

	public void _on_button_button_up()
	{
		ToggleMenu();
	}
}
