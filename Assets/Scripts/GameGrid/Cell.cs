using UnityEngine;
using System.Collections;
using World;

namespace GameGrid
{
	public enum CellState
	{
		Free,
		Occupied,
		Unavailable
	}

	public class Cell 
	{
		private Actor m_Owner;
		public Actor Owner 
		{
			get
			{
				return m_Owner;
			}
			set
			{
				if (m_Owner != value)
				{
					m_Owner = value;
					m_Owner.Position = Position;
				}
			}
		}

		public Position Position {get; private set;}
		public CellState State {get; set;}

		public Cell(int x, int y)
		{
			Position = new Position(x, y);
		}
	}
}