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
	}
}