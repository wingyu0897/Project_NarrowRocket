using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
	private List<ISystem> systems = new List<ISystem>();

	public GameState currentState = GameState.Menu;
	public Action<GameState> OnStateChange;

	public int score;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogWarning("Multiple GameManager is Running");
			Destroy(gameObject);
		}

		systems.Add(GetComponent<LevelSystem>());
		systems.Add(GetComponent<PlayerSystem>());

		UpdateState(GameState.Init);
	}

	private void Start()
	{
		UpdateState(GameState.Standby);
	}

	public void UpdateState(GameState state)
	{
		for (int i = 0; i < systems.Count; i++)
		{
			systems[i].UpdateState(state);
		}

		if (state == GameState.Init)
		{
			UpdateState(GameState.Menu);
		}
	}

	public T GetSystem<T>() where T : class, ISystem
	{
		var value = default(T);

		foreach (var sys in systems.OfType<T>())
		{
			value = sys;
		}

		return value;
	}
}
