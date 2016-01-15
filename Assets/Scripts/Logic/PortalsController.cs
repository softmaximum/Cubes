using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using World;


namespace Logic
{
	public class PortalsController
	{	
		private const float TIME_BEFORE_TELEPORT = 2.0f;
		private List<Portal> m_Portals;

		public PortalsController()
		{
			m_Portals = new List<Portal>();
		}

		public void AddPortal(Portal portal)
		{
			if (!m_Portals.Contains(portal))
			{
				m_Portals.Add(portal);
				portal.OnCollide += (actor) => 
				{
					OnPortalEnter(portal, actor);
				};
			}
		}

		private void OnPortalEnter(Portal portal, Actor actor)
		{
			if (portal != null)
			{
				List<Portal> candidates = m_Portals.Where(x => x != portal).ToList();
				if (candidates.Count > 0)
				{
					candidates[Random.Range(0, candidates.Count)].Teleport(actor, TIME_BEFORE_TELEPORT);
				}
			}
		}
	}
}