using Godot;
using System;

[GlobalClass]
public partial class BaseStats : Resource
{
	[Export] public float MaxHP;
	[Export] public float MaxMP;
	[Export] public float AttackPower;
	[Export] public float AttackSpeed;
	[Export] public float AttackRange;
	[Export] public float Defence;
	[Export] public float Speed;

	public BaseStats() : this( 0, 0, 0, 0, 0, 0, 0) {}

	public BaseStats (float maxHP, float maxMP, float attackPower, float attackSpeed, float attackRange, float defence, float speed)
	{
		MaxHP = maxHP;
		MaxMP = maxMP;
		AttackPower = attackPower;
		AttackSpeed = attackSpeed;
		AttackRange = attackRange;
		Defence = defence;
		Speed = speed;
	}
}
