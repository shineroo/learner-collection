using Godot;
using System;

public partial class CameraController : Camera2D
{
	[Export] public bool spawnSpider = false;
	[Export] int speed = 2;
	[Export] Vector2 minZoom = new Vector2(1, 1);
	[Export] Vector2 maxZoom = new Vector2(3, 3);
	[Export] Vector2 zoomSpeed = new Vector2(0.5f, 0.5f);

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		this.Position += direction * speed;
	}

    public override void _UnhandledInput(InputEvent @event)
    {
		if (@event is InputEventMouseButton mouseButtonEvent){
			if (mouseButtonEvent.ButtonIndex == MouseButton.WheelUp)
			{
				if (Zoom.X <= maxZoom.X)
				{
					Zoom += zoomSpeed;
				}
					
			}
			else if (mouseButtonEvent.ButtonIndex == MouseButton.WheelDown)
			{
				if (Zoom.X >= minZoom.X)
				{
					Zoom -= zoomSpeed;
				}
			}
			if (mouseButtonEvent.ButtonIndex == MouseButton.Left && mouseButtonEvent.Pressed)
			{
				if(spawnSpider)
				{

				
					var scene = GD.Load<PackedScene>("res://prefabs/spider_rat.tscn");
					var instance = scene.Instantiate<Node2D>();
					instance.Position = GetGlobalMousePosition();
					GetTree().Root.AddChild(instance);
				}
			}
		}
    }
}
