using Godot;
using System;

[GlobalClass]
public partial class Skill : Resource
{
    [Export] public string SkillName;
    [Export] public float Cooldown;
    [Export] public int ManaCost = 0;

    public virtual void Execute(Entity target, Entity user)
    {
        Console.WriteLine("base skill executed (this should not happen)");
    }

    public virtual bool CanExecute(Entity target, Entity user)
    {
        return true;
    }

    public Skill() : this(string.Empty, 0){}

    public Skill (string _skillName, float _cooldown)
    {
        SkillName = _skillName;
        Cooldown = _cooldown;
    }
}