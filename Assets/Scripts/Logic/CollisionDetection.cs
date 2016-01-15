using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using World;
using GameGrid;

namespace Logic
{
	public class CollisionDetection
	{
		private Grid m_Grid;
		public List<Actor> Colliders {get; private set;}

		public CollisionDetection(Grid grid)
		{
			m_Grid = grid;
		}

		public void Init(List<Actor> colliders)
		{
			Colliders = colliders;
			for (int i = 0; i < Colliders.Count; i++) 
			{
				Colliders[i].OnPositionChanged += CheckCollision;
			}
		}

		public Actor GetRigid(int x, int y)
		{
			return Colliders.Where(collider => collider.IsRigid && collider.Position.X == x && collider.Position.Y == y).FirstOrDefault();
		}

		public Actor GetRigid(Position position)
		{
			return GetRigid(position.X, position.Y);
		}

		public bool IsInGrid(Position position)
		{
			return position.X >= 0 && position.X < m_Grid.SizeX &&
				   position.Y >= 0 && position.Y < m_Grid.SizeY;
		}

		private void CheckCollision(Actor actor)
		{
			if (actor.IsCollider)
			{
				for (int i = 0; i < Colliders.Count; i++) 
				{
					if (Colliders[i].IsCollider && Colliders[i] != actor)
					{
						if (Colliders[i].Position.X == actor.Position.X && 
						    Colliders[i].Position.Y == actor.Position.Y)
						{
							Colliders[i].OnActorCollide(actor);
							actor.OnActorCollide(Colliders[i]);
						}
					}
				}

			}
		}
	}
}