﻿using UnityEngine;
using System.Collections;

namespace Logic
{
	public abstract class Singletone<T> 
		where T : class, new()
	{
		private static T m_Instance;
		public static T Instance 
		{
			get
			{
				if (m_Instance == null)
				{
					m_Instance = new T();
				}
				return m_Instance;
			}
		}
	}
}