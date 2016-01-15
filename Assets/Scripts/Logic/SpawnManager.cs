using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using World;
using GameGrid;

namespace Logic
{
	public class SpawnManager
	{
		private class SpawnData
		{
			public int X {get; private set;}
			public int Y {get; private set;}
			public int ActorType {get; private set;}
			
			public SpawnData(int x, int y, int actorType)
			{
				X = x;
				Y = y;
				ActorType = actorType;
			}
		}
		private List<SpawnData> m_Data;
		private ActorFactory m_Factory;

		public SpawnManager(ActorFactory factory)
		{
			m_Factory = factory;
		}

		/// <summary>
		/// Spawn actors.
		/// </summary>
		public List<Actor> Spawn(Grid grid)
		{
			List<Actor> result = new List<Actor>();
			foreach (var data in m_Data)
			{
				Actor actor = m_Factory.CreateActor(data.ActorType);
				if (actor != null)
				{
					Cell cell = grid.GetCell(data.X, data.Y);
					if (cell != null)
					{
						actor.TranslateTo(cell.Position);
						actor.Init();
						result.Add(actor);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Loads the SpawnData from file.
		/// </summary>
		public void LoadData(string fileName)
		{
			m_Data = new List<SpawnData>();
			m_Data.Add(new SpawnData(0, 0, 0)); //player
			m_Data.Add(new SpawnData(0, 1, 1)); //brick
			m_Data.Add(new SpawnData(0, 2, 1)); //brick
			m_Data.Add(new SpawnData(0, 3, 1)); //brick
			m_Data.Add(new SpawnData(0, 4, 1)); //brick
			m_Data.Add(new SpawnData(1, 2, 2)); //bomb
			m_Data.Add(new SpawnData(2, 0, 1)); //brick
			m_Data.Add(new SpawnData(2, 1, 1)); //brick
			m_Data.Add(new SpawnData(2, 2, 1)); //brick
			m_Data.Add(new SpawnData(2, 3, 1)); //brick
			m_Data.Add(new SpawnData(2, 4, 1)); //brick
			m_Data.Add(new SpawnData(4, 4, 3)); //portal
			m_Data.Add(new SpawnData(8, 4, 3)); //portal
			m_Data.Add(new SpawnData(6, 9, 3)); //portal
			m_Data.Add(new SpawnData(9, 8, 3)); //portal

		}
	}
}