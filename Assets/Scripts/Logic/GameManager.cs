using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
		private CollisionDetection m_CollisionDetection;

		/// <summary>
		/// Init this instance.
		/// </summary>
		public void Init()
		{
			m_InputManager = new InputManager();
			m_Grid = new Grid();
			m_Grid.Load(GRID_DATA_FILE_NAME);
			m_CollisionDetection = new CollisionDetection(m_Grid);
			SpawnManager spawnManager = new SpawnManager(new ActorFactory(m_InputManager, new PlayerController(m_CollisionDetection), m_CollisionDetection));
			spawnManager.LoadData(SPAWN_DATA_FILE_NAME);
			m_Actors = spawnManager.Spawn(m_Grid);
			m_CollisionDetection.Init(m_Actors);
		}

		/// <summary>
		/// Tick the specified deltaTime.
		/// </summary>
		public void Tick(float deltaTime)
		{
			m_CollisionDetection.Tick(deltaTime);
			m_InputManager.Tick(deltaTime);
			//do reverse tick for proper delete actors
			for (int i = m_Actors.Count - 1; i != 0; i--) 
			{
				if (m_Actors[i].IsDestroyed)
				{
					m_Actors.RemoveAt(i);
				}
				else
				{
					m_Actors[i].Tick(deltaTime);
				}
			}
		}
	}
}