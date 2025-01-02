using Godot;
using System;

[GlobalClass]
public partial class EnemyUnitStats : Resource
{
    [Export] public string Name;
    [Export] public int Level;
    [Export] public int KillXP;
    [Export] public Skill[] Skills;
    // TODO: [Export] public DropTable DropTable;
}
