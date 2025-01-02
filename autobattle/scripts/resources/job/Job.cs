using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Job : Resource
{
    [Export] public string JobName;
    [Export] public Skill[] Skills;

    // TODO: [Export] public Status[] Passives;
    public Job() : this(string.Empty, null) {}

    public Job(string jobName, Skill[] skills)
    {
        JobName = jobName;
        Skills = skills;
    }
}
