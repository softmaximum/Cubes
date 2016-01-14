using UnityEngine;
using System.Collections;
using World;
using Logic;
using GameGrid;

namespace View
{
	public abstract class ActorView<T> : MonoBehaviour
		where T : Actor
	{
		private const float ACTOR_MOVE_SPEED = 10.0f;
		private Coroutine m_Movement;

		public T Parent {get; private set;}

		public virtual void Init(T actor)
		{
			Parent = actor;
			Parent.Initialized += OnActorInitialized;
		}

		private void OnActorInitialized()
		{
			Parent.Initialized -= OnActorInitialized;
			transform.position = new Vector3(Parent.Position.X * Grid.GRID_CELL_SIZE + Grid.GRID_CELL_SIZE / 2.0f, 0.0f, 
			                                 Parent.Position.Y * Grid.GRID_CELL_SIZE + Grid.GRID_CELL_SIZE / 2.0f);
			Parent.PositionChanged += OnPositionChanged;

		}

		private void OnPositionChanged(Actor actor)
		{
			Vector3 target = new Vector3(Parent.Position.X * Grid.GRID_CELL_SIZE + Grid.GRID_CELL_SIZE / 2.0f, 0.0f, 
			                             Parent.Position.Y * Grid.GRID_CELL_SIZE + Grid.GRID_CELL_SIZE / 2.0f);
			if (m_Movement != null)
			{
				StopCoroutine(m_Movement);
			}
			m_Movement = StartCoroutine(MoveToPoint(target, ACTOR_MOVE_SPEED));
		}

		private IEnumerator MoveToPoint(Vector3 target, float speed, System.Action OnFinish = null)
		{		
			bool run = true;
			float oldRange = float.MaxValue;
			Vector3 pos = transform.position;
			Vector3 direction = (target - pos).normalized;
			
			while (run)
			{				
				pos += (direction * Time.deltaTime * speed);
				float range = (pos - target).magnitude;
				run = oldRange > range;
				
				oldRange = range;
				if (run)
				{
					transform.position = pos;
				}
				else
				{
					transform.position = target;
				}
				yield return run;
			}						
			
			if (OnFinish != null)
			{
				OnFinish();				
			}
		}

		private void OnDestroy()
		{
			if (m_Movement != null)
			{
				StopCoroutine(m_Movement);
			}
			if (Parent != null)
			{
				Parent.PositionChanged -= OnPositionChanged;
			}
		}
	}
}