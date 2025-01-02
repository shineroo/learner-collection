using Godot;
using System;
using System.Collections.Generic;
   
public partial class PlayerEntity : Entity
{
	[Export] PlayerUnitStats PlayerUnitStats;

    public override void _Ready()
    {
        base._Ready();
        PlayerUnitStats = (PlayerUnitStats)PlayerUnitStats.Duplicate();
        Attack.SetSkills(PlayerUnitStats.EquippedSkills);
    }

    public override float GetStat(string statName)
	{
		switch (statName)
		{
			case "MaxHP":
				return Stats.MaxHP + PlayerUnitStats.BonusMaxHP;
			case "MaxMP":
				return Stats.MaxMP + PlayerUnitStats.BonusMaxMP;
			case "AttackPower":
				return Stats.AttackPower + PlayerUnitStats.BonusAttackPower;
			case "AttackSpeed":
				return Stats.AttackSpeed + PlayerUnitStats.BonusAttackSpeed;
			case "AttackRange":
				return Stats.AttackRange + PlayerUnitStats.BonusAttackRange;
			case "Defence":
				return Stats.Defence + PlayerUnitStats.BonusDefence;
			case "Speed":
				return Stats.Speed + PlayerUnitStats.BonusSpeed;
			default:
				return 0;
		}
	}
}
