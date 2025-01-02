// this entire thing will have to be redone
// womp womp
using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Pathfinder : NavigationAgent2D
{
	private Vector2 direction;
	private Vector2 targetDestination;
	public Entity theGuyWhoWalks;

    public override void _PhysicsProcess(double delta)
    {
        direction = GetNextPathPosition() - theGuyWhoWalks.Position;
		direction = direction.Normalized();
    }

	public void SetTargetPosition(Vector2 destination)
	{
		TargetPosition = destination;
	}

	public Vector2 GetNextPathDirection()
	{
		return direction;
	}

	// ? this could be in a resource or... idk just somewhere fucking else
	// ? this is also just a very crude immplementation. im sure there are better ways
	public List<Entity> GetEntitiesInGroup(string groupName) 
	{
		Godot.Collections.Array<Node> entitiesArray = GetTree().GetNodesInGroup(groupName);
    	Node[] enemies = new Node[entitiesArray.Count]; // this is magic, GetTree().GetNodesInGroup() doesn't quite give me the type of data i want.
		entitiesArray.CopyTo(enemies, 0);

		List<Entity> entityList = new List<Entity>();
		foreach (Node node in entitiesArray)
		{
			if (node is Entity)
			{
				entityList.Add((Entity)node);
			}
		}
		return entityList;
	}

	// ? im with stupid ^
	public Entity GetNearestEnemy(string EnemyGroup)
	{
		List<Entity> entities = GetEntitiesInGroup(EnemyGroup); // this can be optimised. it checks every entity ever.
		if (entities.Count == 0)
		{
			return null;
		}

		Entity nearestEnemy = entities[0];
		Vector2 currentPosition = theGuyWhoWalks.Position;
		foreach (Entity entity in entities)
		{
			float currentDistance = currentPosition.DistanceTo(entity.Position);
			if (currentDistance < currentPosition.DistanceTo(nearestEnemy.Position))
			{
				nearestEnemy = entity;
			}
		}
		
		return nearestEnemy;
	}
}
