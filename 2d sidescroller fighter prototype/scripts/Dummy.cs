using Godot;
using System;

public partial class Dummy : EntityComponent
{
	private double timer = 5;
	private double currentTimer = 5;

	private float direction = 1;
	private bool facingRight = true;

    public override float GetInputDirection()
    {
        return direction;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (currentTimer >= 0)
		{
			currentTimer -= 0.1;
		}
		else
		{
			currentTimer = timer;
			ToggleDirection();
		}
		if (!facingRight && direction > 0)
		{
			facingRight = true;
			this.ApplyScale(new Vector2(-1, 1));
		}
		if (facingRight && direction < 0)
		{
			facingRight = false;
			this.ApplyScale(new Vector2(-1, 1));
		}
    }

	private void ToggleDirection()
	{
		if(alive)
		{
			switch (direction)
			{
				case 1:
					direction = 0;
					break;
				case -1:
					direction = 0;
					break;
				case 0: 
					if (facingRight)
					{
						direction = -1;
					}
					else 
					{
						direction = 1;
					}
					break;
			}
		}
	}
}
