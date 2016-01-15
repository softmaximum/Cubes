using UnityEngine;
using System.Collections;
using World;

namespace Logic
{
	public class PlayerController
	{
		public CollisionDetection CollisionDetection {get; private set;}
		private ActorFactory m_Factory;
		private Player m_Player; 

		public PlayerController(CollisionDetection collisionDetection, ActorFactory factory)
		{
			CollisionDetection = collisionDetection;
			m_Factory = factory;
		}

		public void Init(Player player)
		{
			m_Player = player;
		}

		public void OnKeyPressed(KeyCode key)
		{
			switch (key)
			{
				case KeyCode.UpArrow:
					MoveTo(new Position(m_Player.Position.X, m_Player.Position.Y + 1));
					break;
				case KeyCode.DownArrow:
					MoveTo(new Position(m_Player.Position.X, m_Player.Position.Y - 1));
					break;
				case KeyCode.LeftArrow:
					MoveTo(new Position(m_Player.Position.X - 1, m_Player.Position.Y));
					break;
				case KeyCode.RightArrow:
					MoveTo(new Position(m_Player.Position.X + 1, m_Player.Position.Y));
					break;
				case KeyCode.Space:
					CreateBomb();
					break;
			}
		}

		private void MoveTo(Position position)
		{
			//Check move to position for collisions
			if (CollisionDetection.IsInGrid(position) && CollisionDetection.GetRigid(position) == null)
			{
				m_Player.MoveTo(position);
			}
		}

		private void CreateBomb()
		{
			Bomb bomb = m_Factory.CreateActor(2) as Bomb;
			bomb.TranslateTo(m_Player.Position.X, m_Player.Position.Y + 1);
			bomb.Init();
		}

	}
}