using UnityEngine;
using System.Collections;
using World;

namespace View
{
	public class PortalView : ActorView<Portal> 
	{
		public override void Init (Portal actor)
		{
			base.Init (actor);
			var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.SetParent(transform, false);
			Collider collider = cube.GetComponent<Collider>();
			cube.transform.localPosition = new Vector3(cube.transform.localPosition.x,
			                                              cube.transform.localPosition.y + collider.bounds.size.y / 2.0f,
			                                              cube.transform.localPosition.z);
			Renderer renderer = cube.GetComponent<Renderer>();
			renderer.material.color = Color.blue;
		}
	}
}