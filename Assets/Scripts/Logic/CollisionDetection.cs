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
		private List<Actor> m_Colliders;
		private Grid m_Grid;

		public CollisionDetection(Grid grid)
		{
			m_Grid = grid;
		}

		public void Init(List<Actor> colliders)
		{
			m_Colliders = colliders;
			for (int i = 0; i < m_Colliders.Count; i++) 
			{
				m_Colliders[i].OnPositionChanged += CheckCollision;
			}
		}

		public Actor GetRigid(int x, int y)
		{
			return m_Colliders.Where(collider => collider.IsRigid && collider.Position.X == x && collider.Position.Y == y).FirstOrDefault();
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
				for (int i = 0; i < m_Colliders.Count; i++) 
				{
					if (m_Colliders[i].IsCollider && m_Colliders[i] != actor)
					{
						if (m_Colliders[i].Position.X == actor.Position.X && 
						    m_Colliders[i].Position.Y == actor.Position.Y)
						{
							m_Colliders[i].OnActorCollide(actor);
							actor.OnActorCollide(m_Colliders[i]);
						}
					}
				}

			}
		}

		public void Tick(float deltaTime)
		{
			for (int i = 0; i < m_Colliders.Count; i++) 
			{
				if (m_Colliders[i].IsRigid)
				{
				}
			}
		}
	}
}