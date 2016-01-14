using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameGrid;
using World;

namespace Logic
{
	public class GameManager
	{
		private const string GRID_DATA_FILE_NAME = "Grid.bin";
		private const string SPAWN_DATA_FILE_NAME = "SpawnData.bin";

		private Grid m_Grid;
		private List<Actor> m_Actors;
		private InputManager m_InputManager;

		/// <summary>
		/// Init this instance.
		/// </summary>
		public void Init()
		{
			m_InputManager = new InputManager();
			m_Grid = new Grid();
			m_Grid.Load(GRID_DATA_FILE_NAME);
			SpawnManager spawnManager = new SpawnManager(new ActorFactory(m_InputManager));
			spawnManager.LoadData(SPAWN_DATA_FILE_NAME);
			m_Actors = spawnManager.Spawn(m_Grid);

		}

		/// <summary>
		/// Tick the specified deltaTime.
		/// </summary>
		public void Tick(float deltaTime)
		{
			m_InputManager.Tick(deltaTime);
			for (int i = 0; i < m_Actors.Count; i++) 
			{
				m_Actors[i].Tick(deltaTime);
			}
		}
	}
}