using Godot;
using System;

[GlobalClass]
public partial class Hurtbox : Area2D
{
	[Signal] public delegate void DamagedEventHandler(int damage);

	public void _on_input_event(Node viewport, InputEvent InputEvent, int shape_idx)
	{
		Console.WriteLine("hehe");
	}

	public override void _Input(InputEvent @event) { 
		if (@event is InputEventMouseButton mouse) 
		{
			
		}
	} 
}
