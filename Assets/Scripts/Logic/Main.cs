using UnityEngine;
using System.Collections;

namespace Logic
{
	public class Main : MonoBehaviour 
	{
		private GameManager m_GameManager;

		// Use this for initialization
		private void Start () 
		{
			m_GameManager = new GameManager();
			m_GameManager.Init();
		}
		
		// Update is called once per frame
		private void Update () 
		{
			m_GameManager.Tick(Time.deltaTime);
		}
	}
}