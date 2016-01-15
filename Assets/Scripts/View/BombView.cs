using UnityEngine;
using System.Collections;
using World;

namespace View
{
	public class BombView : ActorView<Bomb> 
	{
		public override void Init (Bomb actor)
		{
			base.Init (actor);
			var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.transform.SetParent(transform, false);
			Collider collider = sphere.GetComponent<Collider>();
			sphere.transform.localPosition = new Vector3(sphere.transform.localPosition.x,
			                                              sphere.transform.localPosition.y + collider.bounds.size.y / 2.0f,
			                                              sphere.transform.localPosition.z);

		}
	}
}