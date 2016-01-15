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
		public bool CanMove = true;
		public Action Initialized;
		public Action<Actor> OnPositionChanged;
		public Action<Actor> OnTranslate;
		public Action<Actor> OnCollide;
		public Action<Actor> OnDestroy;

		public Position Position
		{
			get
			{
				return m_Position;
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

		public void MoveTo(Position position)
		{
			if (CanMove && (m_Position.X != position.X || m_Position.Y != position.Y))
			{
				m_Position = position;
				if (OnPositionChanged != null)
				{
					OnPositionChanged(this);
				}
			}

		}

		public void TranslateTo(int x, int y)
		{
			m_Position = new Position(x, y);
		}

		public void TranslateTo(Position positon)
		{
			m_Position = positon;
			if (OnTranslate != null)
			{
				OnTranslate(this);
			}
		}

		public virtual void Tick(float deltaTime)
		{

		}
	}
}