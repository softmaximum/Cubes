using UnityEngine;
using System.Collections;
using World;

namespace View
{
	public class BrickView : ActorView<Brick> 
	{
		public override void Init (Brick actor)
		{
			base.Init (actor);
			var capsule = GameObject.CreatePrimitive(PrimitiveType.Cube);
			capsule.transform.SetParent(transform, false);
		}
	}
}