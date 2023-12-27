using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrowLevel : Level
{
	[SerializeField]
	private Transform obstacle;
	[SerializeField]
	private float randomness = 5f;

	private bool isScored = false;

	public override void Initialize()
	{
		isScored = false;
	}

	public override void OnSpawn()
	{
		isScored = false;
		obstacle.position = new Vector3(0, Random.Range(-randomness, randomness), 0);
	}

	private void Update()
	{
		
	}
}
