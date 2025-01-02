using Godot;
using System;

[GlobalClass]
public partial class SelfHealSkill : Skill
{
    [Export] public float heal;

    public override void Execute(Entity target, Entity user)
    {
        user.HealDamage(heal); // todo: negative numbers? no.
    }

    public override bool CanExecute(Entity target, Entity user)
    {
        if (user.Health.GetHealthPercent() < 0.5)
        {
            return true;   
        }
        else
        {
            return false;
        }
    }

    public SelfHealSkill() : this(string.Empty, 0, 0) {}

    public SelfHealSkill (string _skillName, float _cooldown, float _heal)
    {
        Cooldown = _cooldown;
        heal = _heal;
    }
}