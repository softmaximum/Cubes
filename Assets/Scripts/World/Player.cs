using UnityEngine;
using System.Collections;

namespace World
{
	public class Player : Actor
	{
		public Player()
		{

		}

		public override void OnActorCollide (Actor actor)
		{
			base.OnActorCollide (actor);
			Debug.Log(actor);
		}

		public void OnKeyPressed(KeyCode key)
		{
			switch (key)
			{
				case KeyCode.UpArrow:
					MoveTo(new Position(Position.X, Position.Y + 1));
				break;
				case KeyCode.DownArrow:
					MoveTo(new Position(Position.X, Position.Y - 1));
				break;
				case KeyCode.LeftArrow:
					MoveTo(new Position(Position.X - 1, Position.Y));
				break;
				case KeyCode.RightArrow:
					MoveTo(new Position(Position.X + 1, Position.Y));
				break;
			}
		}

		private void MoveTo(Position position)
		{
			Position = position;
		}
	}
}