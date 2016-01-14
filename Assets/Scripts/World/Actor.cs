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
		public Action Initialized;
		public Action<Actor> PositionChanged;
		public Action<Actor> Collide;
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
					if (PositionChanged != null)
					{
						PositionChanged(this);
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
			if (Collide != null)
			{
				Collide(actor);
			}
		}

		public virtual void Tick(float deltaTime)
		{

		}
	}
}