using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Party : Node2D
{
	public List<Entity> PartyMembers;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PartyMembers = new List<Entity>();
		foreach (Node child in GetChildren())
		{
			Console.WriteLine("fuj");
			if (child is Entity partyMember)
			{
				Console.WriteLine("BLET");
				PartyMembers.Add(partyMember);
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void RemovePartyMember(Entity partyMember)
	{
		PartyMembers.Remove(partyMember);
	}

	public void AddPartyMember(Entity partyMember)
	{
		PartyMembers.Add(partyMember);
	}

	public Entity GetLowestHealthMember()
	{
		Entity lowestHealth = PartyMembers.OrderBy(p => p.Health.currentHealth).First();
		return lowestHealth;
	}
}
