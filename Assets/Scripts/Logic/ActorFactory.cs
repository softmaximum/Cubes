using UnityEngine;
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
		private CollisionDetection m_CollisionDetection;
		private PortalsController m_PortalsController;
		private Dictionary<int, CreateActorAction> IntToActorType;
		private List<Actor> m_Actors;

		public ActorFactory(List<Actor> actors, InputManager inputManager, CollisionDetection collisionDetection, PortalsController portalsController)
		{
			IntToActorType = new Dictionary<int, CreateActorAction>()
			{
				{0, CreatePlayer},
				{1, CreateBrick},
				{2, CreateBomb},
				{3, CreatePortal},
			};

			m_InputManager = inputManager;
			m_CollisionDetection = collisionDetection;
			m_PortalsController = portalsController;
			m_Actors = actors;
		}

		private Actor CreatePlayer()
		{
			Player player = new Player();
			GameObject go = new GameObject("Player");
			go.transform.localScale *= VIEW_SCALE_FACTOR;
			PlayerView view = go.AddComponent<PlayerView>();
			view.Init(player);
			PlayerController playerController = new PlayerController(m_CollisionDetection, this);
			m_InputManager.KeyPressed += playerController.OnKeyPressed;
			playerController.Init(player);
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

		private Actor CreatePortal()
		{
			Portal portal = new Portal();
			GameObject go = new GameObject("Portal");
			go.transform.localScale *= VIEW_SCALE_FACTOR;
			PortalView view = go.AddComponent<PortalView>();
			view.Init(portal);
			m_PortalsController.AddPortal(portal);
			return portal;
		}

		public Actor CreateActor(int actorType)
		{
			if (IntToActorType.ContainsKey(actorType))
			{
				var action = IntToActorType[actorType];
				Actor result = action();
				m_Actors.Add(result);
				return result;
			}
			return null;
		}
	}
}