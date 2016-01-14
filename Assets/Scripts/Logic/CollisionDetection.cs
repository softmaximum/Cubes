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

		public CollisionDetection(List<Actor> colliders)
		{
			m_Colliders = colliders;
		}

		public void Init()
		{
			for (int i = 0; i < m_Colliders.Count; i++) 
			{
				m_Colliders[i].PositionChanged += CheckCollision;
			}
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
				if (m_Colliders[i].IsCollider)
				{
					for (int j = i + 1; j < m_Colliders.Count; j++) 
					{
						if (m_Colliders[j].IsCollider)
						{
							if (m_Colliders[i].Position.X == m_Colliders[j].Position.X && 
							    m_Colliders[i].Position.Y == m_Colliders[j].Position.Y)
							{
								m_Colliders[i].OnActorCollide(m_Colliders[j]);
								m_Colliders[j].OnActorCollide(m_Colliders[i]);
							}
						}
					}
				}
			}
		}
	}
}