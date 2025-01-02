using Godot;
using System;

public partial class Player : EntityComponent
{
    public override void _Ready()
    {
        jumpsAvailable = maxAirJumps;
    }

    public override float GetInputDirection()
	{
		float direction = Input.GetAxis("left", "right");
		// not a fan of this
		if (_facingRight && direction < 0)
		{
			_facingRight = false;
			this.ApplyScale(new Vector2(-1, 1));
		}
		if (!_facingRight && direction > 0)
		{
			_facingRight = true;
			this.ApplyScale(new Vector2(-1, 1));
		}
		return direction;		
	}

    public override void _PhysicsProcess(double delta)
    {
        if (IsOnFloor())
		{
			jumpsAvailable = maxAirJumps;
		}
		if (Input.IsActionJustPressed("jump") && !IsOnFloor())
		{
			jumpsAvailable--;
		}
    }

    public override bool GetAttack()
    {
        if (Input.IsActionJustPressed("jump"))
		{
			return false;
		}
		else
		{
			return Input.IsActionJustPressed("attack1");
		}
    }

    public override bool GetJump()
    {
		if (jumpsAvailable >= 0)
		{
			return Input.IsActionJustPressed("jump");
		}
		else 
		{
			return false;
		}		
    }

    public override bool GetDash()
    {
        return Input.IsActionJustPressed("shift");
    }

    public Vector2 GetMouse()
	{
		Vector2 mousePos = GetLocalMousePosition();
		if (!_facingRight)
		{
			GD.Print("im trying to reverse it");
			
			mousePos.X = mousePos.X * -1;
		}
		if (mousePos.X < 0 && _facingRight)
		{
			_facingRight = false;
			this.ApplyScale(new Vector2(-1, 1));
		}
		if (mousePos.X > 0 && !_facingRight)
		{
			_facingRight = true;
			this.ApplyScale(new Vector2(-1, 1));
		}

		return mousePos;
	}
}
