using UnityEngine;
using System.Collections;
using World;

namespace View
{
	public class BrickView : ActorView<Brick> 
	{
		private const string BRICK_MATERIAL_PATH = "Materials/Brick";
		public override void Init (Brick actor)
		{
			base.Init (actor);
			var brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
			brick.transform.SetParent(transform, false);
			Collider collider = brick.GetComponent<Collider>();
			brick.transform.localPosition = new Vector3(brick.transform.localPosition.x,
			                                            brick.transform.localPosition.y + collider.bounds.size.y / 2.0f,
			                                            brick.transform.localPosition.z);
			Renderer renderer = brick.GetComponent<Renderer>();
			if (renderer != null)
			{
				renderer.material = Resources.Load<Material>(BRICK_MATERIAL_PATH);
			}
		}
	}
}