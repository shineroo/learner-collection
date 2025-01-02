using Godot;
using System;

public partial class AttackState : State
{
	[Export] private State nextAttack;
    [Export] private State defaultState;
    [Export] private float attackMoveModifier = 1;
    [Export] private bool canMove = false;
    [Export] private bool jumpCancelable = false;
    [Export] private bool landCancelable = false;

    private bool animationFinished = false;
    private bool goToNextAttack = false;
    private bool hitboxEnabled = false;
    private int landCancelReady = 0;

    public override void Enter()
    {
        goToNextAttack = false;
        animationFinished = false;
        landCancelReady = 0;
        //EnableHitbox();
        move.SetVelocityX(entity.GetInputDirection() * attackMoveModifier);
    }

    public override void PhysicsUpdate(double delta)
    {
        if (canMove)
        {
            float inputDirection = entity.GetInputDirection();
		    move.SetVelocityX(inputDirection);
        }
        else
        {
            move.LerpVelocityX(0, 0.4f);
        }

        if (entity.GetAttack())
        {
            goToNextAttack = true;
        }
        if (animationFinished)
        {
            if (goToNextAttack)
            {
                stateMachine.TransitionTo(nextAttack.Name);
            }
            else 
            {
                stateMachine.TransitionTo(defaultState.Name);
            }
        }
        if (jumpCancelable && entity.GetJump())
        {
            DisableHitbox();
            stateMachine.TransitionTo("Jump");
        }  
        if (landCancelable && entity.IsOnFloor())
        {
            DisableHitbox();
            stateMachine.TransitionTo("Idle");
        }
        if (entity.GetDash())
        {
            stateMachine.TransitionTo("Dash");
        }
    }

    public void EnableHitbox()
    {
        stateMachine.SendEnableHitbox(this.Name);
    }

    public void DisableHitbox()
    {
        stateMachine.SendDisableHitbox(this.Name);
    }

    private void _on_sprite_animation_finished(string key)
	{
        animationFinished = true;  
	}
}
