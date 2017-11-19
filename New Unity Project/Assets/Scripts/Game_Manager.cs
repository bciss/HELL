using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

	public	Text	txt;
	public	Image	gameover;
	public	bool	lost;
	[HideInInspector]
	public	bool	GameState;
	private	int		Score;
	private	int		i;
	private	int		j;

	// Use this for initialization
	void Start () {
		i = 0;
		j = 0;
		GameState = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (lost && gameover.rectTransform.localScale.x < 5)
		{
			gameover.rectTransform.localScale += new Vector3(0.01f,0.01f,0);
			gameover.color += new Color(0,0,0, 0.005f);
		}
	}

	public void ScoreUp (int points) {
		Score += points;
		txt.GetComponent<Text>().text = "Score : " + Score.ToString();
	}

	public void GameOver () {
		GameState = false;
		lost = true;
		Debug.Log("GAME OVER");
	}
}
