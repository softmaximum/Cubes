using UnityEngine;
using System.Collections;

namespace World
{
	public class Portal : Actor
	{
		private Actor m_TeleportActor;

		public float TimeBeforeTeleport {get; private set;}
		public float CurrentTime {get; private set;}

		public Portal()
		{

		}

		public void Teleport(Actor actor, float timeBeforeTeleport)
		{
			actor.CanMove = false;
			m_TeleportActor = actor;
			TimeBeforeTeleport = timeBeforeTeleport;
			CurrentTime = timeBeforeTeleport;
		}

		public override void Tick (float deltaTime)
		{
			base.Tick (deltaTime);
			if (CurrentTime > 0)
			{
				CurrentTime -= deltaTime;
				if (CurrentTime <= 0 && m_TeleportActor != null)
				{
					m_TeleportActor.CanMove = true;
					m_TeleportActor.TranslateTo(Position);
					m_TeleportActor = null;
				}
			}
		}
	}
}