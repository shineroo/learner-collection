using Godot;
using System;

public partial class EnemyEntity : Entity
{
	[Export] EnemyUnitStats EnemyUnitStats;

    public override void _Ready()
    {
        base._Ready();
        EnemyUnitStats = (EnemyUnitStats)EnemyUnitStats.Duplicate();
        Attack.SetSkills(EnemyUnitStats.Skills);
    }
}
