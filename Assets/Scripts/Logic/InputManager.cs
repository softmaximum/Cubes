using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Logic
{
	public class InputManager 
	{
		private Dictionary<KeyCode, Action> KeyBundings;

		public Action UpArrowPressed;
		public Action DownArrowPressed;
		public Action LeftArrowPressed;
		public Action RightArrowPressed;
		public Action<KeyCode> KeyPressed; 

		public InputManager()
		{
			KeyBundings = new Dictionary<KeyCode, Action>()
			{
				{KeyCode.UpArrow, () => {if (UpArrowPressed != null) UpArrowPressed();}},
				{KeyCode.DownArrow, () => {if (UpArrowPressed != null) DownArrowPressed();}},
				{KeyCode.LeftArrow, () => {if (UpArrowPressed != null) LeftArrowPressed();}},
				{KeyCode.RightArrow, () => {if (UpArrowPressed != null) RightArrowPressed();}},
			};
		}

		/// <summary>
		/// Tick the specified deltaTime.
		/// </summary>
		public void Tick(float deltaTime)
		{
			if (Input.anyKeyDown)
			{
				for (int i = 0; i < KeyBundings.Keys.Count; i++) 
				{
					KeyCode key = KeyBundings.Keys.ElementAt(i);
					if (Input.GetKeyUp(key))
					{
						KeyBundings[key]();
					}
				}
				if (KeyPressed != null)
				{
					foreach(KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
					{
						if(Input.GetKeyDown(key))
						{
							KeyPressed(key);
						}
					}
				}
			}
		}
	}
}