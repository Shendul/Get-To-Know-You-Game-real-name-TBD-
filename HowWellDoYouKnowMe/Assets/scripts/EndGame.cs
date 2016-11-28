using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public GameObject endScoresText;

	// Use this for initialization
	void Start () {
		string endScoresString = "";
		for (int i = 0; i < GameModel.numberOfTeams; i++){
			endScoresString += "Team " + i + "'s Score: ";
			endScoresString += GameModel.teamScoreList[i];
			endScoresString += "\n----------------\n\n\n";
		}
		endScoresText.GetComponent<Text>().text = endScoresString;
	}

	public void EndTheGame() {
		
		//GameModel.teamScoreList;
		Application.LoadLevel("start_scene");
	}
}
