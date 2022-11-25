using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;

	public Text scoreText;
	public Text highScoreText;

	int score = 0;
	int highScore = 0;

	private void Awake() {
		instance = this;
	}

	void Start(){
	highScore = PlayerPrefs.GetInt("highscore", 0);
	scoreText.text = score.ToString() + " POINTS";
	highScoreText.text = "HIGHSCORE: " + highScore.ToString();
	}

	public void AddPoint(){
		score += 1;
		scoreText.text = score.ToString() + " POINTS";
		if (highScore<score)
			PlayerPrefs.SetInt("highscore", score);
	}
}