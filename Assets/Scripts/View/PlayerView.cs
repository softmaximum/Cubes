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
			Collider collider = capsule.GetComponent<Collider>();
			capsule.transform.localPosition = new Vector3(capsule.transform.localPosition.x,
			                                              capsule.transform.localPosition.y + collider.bounds.size.y / 2.0f,
			                                              capsule.transform.localPosition.z);

		}
	}
}