using Godot;
using System;

[GlobalClass]
public partial class HealSkill : Skill
{
    [Export] public float heal;

    public override void Execute(Entity target, Entity user)
    {
        target.TakeDamage(heal * -1, user); // todo: negative numbers? no.
    }

    public override bool CanExecute(Entity target, Entity user)
    {
        return base.CanExecute(target, user);
    }

    public HealSkill() : this(string.Empty, 0, 0) {}

    public HealSkill (string _skillName, float _cooldown, float _heal)
    {
        SkillName = _skillName;
        Cooldown = _cooldown;
        heal = _heal;
    }
}