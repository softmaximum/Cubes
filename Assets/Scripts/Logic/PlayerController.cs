using UnityEngine;
using System.Collections;
using World;

namespace Logic
{
	public class PlayerController
	{
		private CollisionDetection m_CollisionDetection;
		private Player m_Player; 

		public PlayerController(CollisionDetection collisionDetection)
		{
			m_CollisionDetection = collisionDetection;
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
			}
		}

		private void MoveTo(Position position)
		{
			if (m_CollisionDetection.IsInGrid(position) && m_CollisionDetection.GetRigid(position) == null)
			{
				m_Player.Position = position;
			}

		}

	}
}