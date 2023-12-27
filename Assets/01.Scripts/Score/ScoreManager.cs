using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public bool isActive = false;
	public int score;

	private int bestScore;

	private Color textOriginColor;

	private void Awake()
	{
		bestScore = PlayerPrefs.GetInt("BestScore", 0);
	}

	private void ChangeScore(int scoreInput)
	{
	}

	public void Initialize()
	{
		isActive = false;
		score = 0;
	}

	public void StartScoring()
	{
		isActive = true;
	}

	public void StopScoring()
	{
		isActive = false;

		if (score > bestScore)
		{
			bestScore = score;
			PlayerPrefs.SetInt("BestScore", bestScore);
		}
	}
}
