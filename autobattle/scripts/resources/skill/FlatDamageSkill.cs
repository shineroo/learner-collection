using Godot;
using System;

[GlobalClass]
public partial class FlatDamageSkill : Skill
{
    [Export] public float damage;
    [Export] public float range;

    public override void Execute(Entity target, Entity user)
    {
        Console.WriteLine($"skill {base.SkillName} executed. {damage} damage dealt");
        user.InflictDamage(target, damage);
    }

    public override bool CanExecute(Entity target, Entity user)
    {
        if (user.Position.DistanceTo(target.Position) <= range)
        {
            return true;
        }
        return false;
    }

    public FlatDamageSkill() : this(string.Empty, 0, 0) {}

    public FlatDamageSkill (string _skillName, float _cooldown, float _damage)
    {
        SkillName = _skillName;
        Cooldown = _cooldown;
        damage = _damage;
    }
}
