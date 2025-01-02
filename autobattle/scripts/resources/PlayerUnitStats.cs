using Godot;
using System;

[GlobalClass]
public partial class PlayerUnitStats : Resource
{
	[Export] public string Name;
	[Export] public float BonusMaxHP;
	[Export] public float BonusMaxMP;
	[Export] public float BonusAttackPower;
	[Export] public float BonusAttackSpeed;
	[Export] public float BonusAttackRange;
	[Export] public float BonusDefence;
	[Export] public float BonusSpeed;
	[Export] public Job Job; 
	// TODO: [Export] public Status[] EquippedPassives;
	// TODO: [Export] public Item[] Invetory; [Export] public int InventorySize;

	public PlayerUnitStats() : this(string.Empty, 0, 0, 0, 0, 0, 0, 0, null) {}

    public PlayerUnitStats(string name, float bonusMaxHP, float bonusMaxMP, float bonusAttackPower,
        float bonusAttackSpeed, float bonusAttackRange, float bonusDefence, float bonusSpeed, Job job)
    {
        Name = name;
        BonusMaxHP = bonusMaxHP;
        BonusMaxMP = bonusMaxMP;
        BonusAttackPower = bonusAttackPower;
        BonusAttackSpeed = bonusAttackSpeed;
        BonusAttackRange = bonusAttackRange;
        BonusDefence = bonusDefence;
        BonusSpeed = bonusSpeed;
        Job = job;
    }
}
