﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Logic;

namespace World
{
	public class Bomb : Actor
	{
		private const float LIFE_TIME_MIN = 5.0f;
		private const float LIFE_TIME_MAX = 15.0f;

		public float LifeTime {get; private set;}
		public float CurrentTime {get; private set;}
		private CollisionDetection m_CollisionDetection;

		public Bomb(CollisionDetection collisionDetection)
		{
			LifeTime = Random.Range(LIFE_TIME_MIN, LIFE_TIME_MAX);
			CurrentTime = LifeTime;
			m_CollisionDetection = collisionDetection;
			IsRigid = true;
		}

		public override void Tick (float deltaTime)
		{
			base.Tick (deltaTime);
			CurrentTime -= deltaTime;
			if (CurrentTime <= 0)
			{
				Destroy();
			}
		}

		public override void Destroy ()
		{
			base.Destroy ();
			List<Actor> actors = new List<Actor>();
			AddAffectedCollider(actors, Position.X, Position.Y + 1);
			AddAffectedCollider(actors, Position.X + 1, Position.Y);
			AddAffectedCollider(actors, Position.X, Position.Y - 1);
			AddAffectedCollider(actors, Position.X - 1, Position.Y);

			for (int i = 0; i < actors.Count; i++) 
			{
				actors[i].Destroy();
			}
		}

		private void AddAffectedCollider(List<Actor> actors, int x, int y)
		{
			var actor = m_CollisionDetection.GetRigid(x, y);
			if (actor != null)
			{
				actors.Add(actor);
			}
		}
	}
}