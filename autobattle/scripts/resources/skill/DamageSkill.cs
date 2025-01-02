using Godot;
using System;

[GlobalClass]
public partial class DamageSkill : Skill
{
    [Export] public float DamageMult;

    public override void Execute(Entity target, Entity user)
    {
        Console.WriteLine($"skill {base.SkillName} executed. {user.GetStat("AttackPower")} damage dealt");
        user.InflictDamage(target, user.GetStat("AttackPower") * DamageMult);
    }

    public override bool CanExecute(Entity target, Entity user)
    {
        if (user.Position.DistanceTo(target.Position) <= user.GetStat("AttackRange"))
        {
            return true;
        }
        return false;
    }

    public DamageSkill() : this(string.Empty, 0, 0) {}

    public DamageSkill (string skillName, float cooldown, float damageMult)
    {
        SkillName = skillName;
        Cooldown = cooldown;
        DamageMult = damageMult;
    }
}
