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
						cell.Owner = actor;
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
			m_Data.Add(new SpawnData(0, 0, 0));
			m_Data.Add(new SpawnData(0, 1, 1));
			m_Data.Add(new SpawnData(0, 2, 1));
			m_Data.Add(new SpawnData(0, 3, 1));
			m_Data.Add(new SpawnData(0, 4, 1));
		}
	}
}