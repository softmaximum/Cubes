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

		private Dictionary<int, CreateActorAction> IntToActorType;

		public ActorFactory(InputManager inputManager)
		{
			IntToActorType = new Dictionary<int, CreateActorAction>()
			{
				{0, CreatePlayer},
				{1, CreateBrick}
			};

			m_InputManager = inputManager;
		}

		private Actor CreatePlayer()
		{
			Player player = new Player();
			GameObject go = new GameObject("Player");
			go.transform.localScale *= VIEW_SCALE_FACTOR;
			PlayerView view = go.AddComponent<PlayerView>();
			view.Init(player);
			m_InputManager.KeyPressed += player.OnKeyPressed;
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