using UnityEngine;
using System.Collections;
using System;
using Logic;

namespace World
{
	public struct Position
	{
		public int X;
		public int Y;

		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	public abstract class Actor
	{
		protected Position m_Position;

		public bool IsCollider = true;
		public bool IsRigid;
		public bool IsDestroyed {get; private set;}
		public Action Initialized;
		public Action<Actor> OnPositionChanged;
		public Action<Actor> OnPositionImmediateChanged;
		public Action<Actor> OnCollide;
		public Action<Actor> OnDestroy;

		public Position Position
		{
			get
			{
				return m_Position;
			}
			set
			{
				if (m_Position.X != value.X || m_Position.Y != value.Y)
				{
					m_Position = value;
					if (OnPositionChanged != null)
					{
						OnPositionChanged(this);
					}
				}
			}
		}

		public void Init()
		{
			if (Initialized != null)
			{
				Initialized();
			}
		}

		public virtual void OnActorCollide(Actor actor)
		{
			if (OnCollide != null)
			{
				OnCollide(actor);
			}
		}

		public virtual void Destroy()
		{
			IsDestroyed = true;
			if (OnDestroy != null)
			{
				OnDestroy(this);
			}
		}

		public void MoveImmediateTo(int x, int y)
		{
			m_Position = new Position(x, y);
		}

		public void MoveImmediateTo(Position positon)
		{
			m_Position = positon;
			if (OnPositionImmediateChanged != null)
			{
				OnPositionImmediateChanged(this);
			}
		}

		public virtual void Tick(float deltaTime)
		{

		}
	}
}