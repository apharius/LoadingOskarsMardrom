using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    private GameStateHandler gameStateHandler;
	// Use this for initialization
	void Start () {
        gameStateHandler = GameObject.Find("GameStateHandler").GetComponent<GameStateHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        Text scoreText = GetComponent<Text>();
        scoreText.text = "Poäng: " + gameStateHandler.score;
    }
}
