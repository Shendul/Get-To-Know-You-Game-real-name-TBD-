using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public InputField numberOfTeamsInputField;

	// Use this for initialization
	public void StartGame () {
	
		GameModel.numberOfTeams = Int32.Parse(numberOfTeamsInputField.text);
		Debug.Log (GameModel.numberOfTeams);
		GameModel.teamScoreList = new int[GameModel.numberOfTeams];
		GameModel.currentRound = 1;
		Application.LoadLevel("game_scene");
		GameModel.turn = "Q";
	}
	
	// Update is called once per frame
	void Update () {
	}
}
