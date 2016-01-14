using UnityEngine;
using System.Collections;

namespace World
{
	public class Player : Actor
	{
		public Player()
		{
		}

		public void OnKeyPressed(KeyCode key)
		{
			switch (key)
			{
				case KeyCode.UpArrow:
					Position = new Position(Position.X, Position.Y + 1);
				break;
				case KeyCode.DownArrow:
					Position = new Position(Position.X, Position.Y - 1);
				break;
				case KeyCode.LeftArrow:
					Position = new Position(Position.X - 1, Position.Y);
				break;
				case KeyCode.RightArrow:
					Position = new Position(Position.X + 1, Position.Y);
				break;
			}
		}

		private void MoveTo(Position position)
		{

		}
	}
}