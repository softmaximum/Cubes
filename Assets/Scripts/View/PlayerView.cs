using UnityEngine;
using System.Collections;
using World;

namespace View
{
	public class PlayerView : ActorView<Player> 
	{
		public override void Init (Player actor)
		{
			base.Init (actor);
			var capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			capsule.transform.SetParent(transform, false);
		}
	}
}