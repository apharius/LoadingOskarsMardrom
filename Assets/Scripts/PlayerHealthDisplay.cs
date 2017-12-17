using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour {

    public PlayerBehavior player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text healthText = GetComponent<Text>();
        healthText.text = "Hälsa: " + player.health;
	}
}
