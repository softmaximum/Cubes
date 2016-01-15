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
		public Position Position {get; private set;}
		public CellState State {get; set;}

		public Cell(int x, int y)
		{
			Position = new Position(x, y);
		}
	}
}