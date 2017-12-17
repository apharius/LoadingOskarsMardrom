using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int lastScore = PlayerPrefs.GetInt("LastScore",0);
        int topScore = PlayerPrefs.GetInt("TopScore",0);

        if(lastScore > topScore)
        {
            topScore = lastScore;
            PlayerPrefs.SetInt("TopScore", topScore);
        }

        string resultsString = string.Format("Omgångspoäng: {0}\nHögsta poäng: {1}", lastScore, topScore);
        gameObject.GetComponent<Text>().text = resultsString;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
