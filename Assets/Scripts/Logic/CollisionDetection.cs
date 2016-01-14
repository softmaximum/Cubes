using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using World;

namespace Logic
{
	public class CollisionDetection
	{
		private List<Actor> m_Colliders;
	
		public void Init(List<Actor> colliders)
		{
			m_Colliders = colliders;
			for (int i = 0; i < m_Colliders.Count; i++) 
			{
				m_Colliders[i].PositionChanged += CheckCollision;
			}
		}

		public Actor IsRigidPosition(Position position)
		{
			return m_Colliders.Where(x => x.IsRigid && x.Position.X == position.X && x.Position.Y == position.Y).FirstOrDefault();
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