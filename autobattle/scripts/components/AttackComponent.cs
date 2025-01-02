// functionally, these are only basic attacks.
// special skills should have their own component (SkillComponent)
// perhaps then weaponskill should also have their own components

using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

[GlobalClass]
public partial class AttackComponent : Node
{
	private float GlobalCooldown = 3;
	private float CurrentCooldown = 0;
	private List<Skill> Skills;
	private float[] SkillCooldowns; 
	private int SkillCount = 1;

    public override void _Ready()
    {
        SkillCooldowns = new float[7];
		
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		if (CurrentCooldown > 0)
		{
			CurrentCooldown -= (float)delta;
		}
		for (int i = 0; i < SkillCooldowns.Length; i++)
		{
			if (SkillCooldowns[i] > 0)
			{
				SkillCooldowns[i] -= (float)delta;
			}
		}
	}

	public void TryAttack(Entity target, Entity user)
	{
		if (CurrentCooldown <= 0)
		{
			for (int i = 0; i < Skills.Count; i++)
			{
				Console.WriteLine($"checking if i can do {Skills[i].SkillName}. {Skills[i].CanExecute(target, user)}");
				if (Skills[i].CanExecute(target, user) && SkillCooldowns[i] <= 0)
				{
					SkillCooldowns[i] = Skills[i].Cooldown;
					CurrentCooldown = GlobalCooldown;
					Skills[i].Execute(target, user);
					break;
				}
			}
			Console.WriteLine("======");
		}
	}

	public void SetSkills(Skill[] skills)
	{
		if (skills == null || skills.Length == 0) 
		{
			Skills = new List<Skill>
            {
                new DamageSkill("Basic Attack", 3, 1) // TODO: i might want to make this weapon specific later.
            };
			return;
		}
		Skills = skills.ToList();
		Skills.Add(new DamageSkill("Basic Attack", 3, 1));
		
	}
}
