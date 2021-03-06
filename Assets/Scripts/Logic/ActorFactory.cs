﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using World;
using View;

namespace Logic
{
	public class ActorFactory 
	{
		private const float VIEW_SCALE_FACTOR = 1.0f;
		private delegate Actor CreateActorAction();
		private InputManager m_InputManager;
		private PlayerController m_PlayerController;
		private CollisionDetection m_CollisionDetection;

		private Dictionary<int, CreateActorAction> IntToActorType;

		public ActorFactory(InputManager inputManager, PlayerController playerController, CollisionDetection collisionDetection)
		{
			IntToActorType = new Dictionary<int, CreateActorAction>()
			{
				{0, CreatePlayer},
				{1, CreateBrick},
				{2, CreateBomb},
			};

			m_InputManager = inputManager;
			m_PlayerController = playerController;
			m_CollisionDetection = collisionDetection;
		}

		private Actor CreatePlayer()
		{
			Player player = new Player();
			GameObject go = new GameObject("Player");
			go.transform.localScale *= VIEW_SCALE_FACTOR;
			PlayerView view = go.AddComponent<PlayerView>();
			view.Init(player);
			m_InputManager.KeyPressed += m_PlayerController.OnKeyPressed;
			m_PlayerController.Init(player);
			return player;
		}

		private Actor CreateBrick()
		{
			Brick brick = new Brick();
			GameObject go = new GameObject("Brick");
			go.transform.localScale *= VIEW_SCALE_FACTOR;
			BrickView view = go.AddComponent<BrickView>();
			view.Init(brick);
			return brick;
		}

		private Actor CreateBomb()
		{
			Bomb bomb = new Bomb(m_CollisionDetection);
			GameObject go = new GameObject("Bomb");
			go.transform.localScale *= VIEW_SCALE_FACTOR;
			BombView view = go.AddComponent<BombView>();
			view.Init(bomb);
			return bomb;
		}

		public Actor CreateActor(int actorType)
		{
			if (IntToActorType.ContainsKey(actorType))
			{
				var action = IntToActorType[actorType];
				return action();
			}
			return null;
		}
	}
}