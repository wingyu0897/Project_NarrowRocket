using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour, ISystem
{
	[SerializeField]
	private Movement movement;

	public void UpdateState(GameState state)
	{
		switch (state)
		{
			case GameState.Init:
				movement.Initialize();
				break;
			case GameState.Standby:
				break;
			case GameState.Running:
				movement.ActiveMovement();
				break;
			case GameState.Result:
				movement.DeactiveMovement();
				break;
		}
	}
}
