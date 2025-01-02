using Godot;
using System;

[GlobalClass]
public partial class Entity : CharacterBody2D
{
	private Entity CurrentTarget;
	private float NewTargetCooldown = 0.1f;
	private float NewTargetTimer = 0;

	[Export] public string EnemyGroup = "enemies";
	[Export] public BaseStats Stats;

	[Export] public AttackComponent Attack;
	[Export] public AnimationPlayer AnimationPlayer;
	[Export] public MoveComponent Move;
	[Export] public Hurtbox Hurtbox;
	[Export] public Health Health;
	[Export] public Pathfinder Pathfinder;

	public bool Alive = true; 
	private protected bool HasTarget = false;


    public override void _Ready()
    {
		Stats = (BaseStats)Stats.Duplicate();
        Health.SetMaxHP(Stats.MaxHP);
		Health.HealDamage(88888);
		Move.Speed = Stats.Speed;
		Pathfinder.theGuyWhoWalks = this;

		CurrentTarget = this;
    }

    public override void _Process(double delta)
    {
        NewTargetTimer -= (float)delta;
		UpdateTarget();
		UpdateMoveDirection();
		// todo: tick status lengths

		
		if (DistanceToTarget() <= Stats.AttackRange && HasTarget && CurrentTarget != this)
		{
			Attack.TryAttack(CurrentTarget, this); // this can be optimized
			ResetVelocity();
		}
		else
		{
			Move.Move(this);
		}
		AnimationPlayer.PlayAnimation(Move.GetVelocity());
    }

	private void UpdateTarget()
	{
		if (HasTarget && !CurrentTarget.Alive)
		{
			CurrentTarget = this;
			HasTarget = false;
		}
		// check for new targets when timer is up
		if (NewTargetTimer <= 0)
		{
			NewTargetTimer = NewTargetCooldown;
			// todo: this should eventually have a range
			if (Pathfinder.GetNearestEnemy(EnemyGroup) is Entity entity)
			{
				CurrentTarget = entity;
				HasTarget = true;
			}
			else
			{
				CurrentTarget = this;
				HasTarget = false;
			}
			
			Pathfinder.SetTargetPosition(CurrentTarget.Position);
		}
	}

    public void TakeDamage(float damage, Entity attacker) 
	{
		// todo: statuses
		Health.TakeDamage(damage);
		if (Health.currentHealth <= 0)
		{
			Alive = false;
			QueueFree();
		}
	}

	public void HealDamage(float heal)
	{
		Health.HealDamage(heal);
	}

	public void InflictDamage(Entity target, float damage)
	{
		// todo: statuses
		target.TakeDamage(damage, this);
	}

	// ? this might be temporary
	private void UpdateMoveDirection()
	{
		if (!HasTarget)
		{
			ResetVelocity();
			return;
		}
		if (CurrentTarget.Alive)
		{
			Move.SetVelocity(Pathfinder.GetNextPathDirection());
		}
		else
		{
			UpdateTarget();
		}	
	}

	private void ResetVelocity()
	{
		Move.SetVelocity(Vector2.Zero);
	}

	private float DistanceToTarget()
	{
		return Position.DistanceTo(CurrentTarget.Position);
	}

	
	public virtual float GetStat(string statName)
	{
		switch (statName)
		{
			case "MaxHP":
				return Stats.MaxHP;
			case "MaxMP":
				return Stats.MaxMP;
			case "AttackPower":
				return Stats.AttackPower;
			case "AttackSpeed":
				return Stats.AttackSpeed;
			case "AttackRange":
				return Stats.AttackRange;
			case "Defence":
				return Stats.Defence;
			case "Speed":
				return Stats.Speed;
			default:
				return 0;
		}
	}
}
