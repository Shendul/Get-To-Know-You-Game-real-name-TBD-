using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	public GameObject endScoresText;

	// Use this for initialization
	void Start () {
		string endScoresString = "";
        int winnersIndex = 0;
        bool isTie = false;
        for (int i = 1; i < GameModel.numberOfTeams; i++){
            Debug.Log("End Scoring comparison (i): " + i);
            Debug.Log("End Scoring comparison (end point): " + (GameModel.numberOfTeams));
            if (GameModel.teamScoreList[i] > GameModel.teamScoreList[winnersIndex]) {
                winnersIndex = i;
                isTie = false;
                Debug.Log( (GameModel.teamScoreList[i]) + " > " + (GameModel.teamScoreList[winnersIndex]) );
            } else if (GameModel.teamScoreList[i] < GameModel.teamScoreList[winnersIndex]) {
                isTie = false;
                Debug.Log((GameModel.teamScoreList[i]) + " < " + (GameModel.teamScoreList[winnersIndex]));
            } else { isTie = true; Debug.Log("End Scoring inside tie conditon"); }
        }
        if (isTie) {
            endScoresString += "The game is a Tie!\n\n";
        } else {
            endScoresString += "The winner is Team " + winnersIndex + "!\n\n";
        }
		for (int i = 0; i < GameModel.numberOfTeams; i++){
			endScoresString += "Team " + i + "'s Score: ";
			endScoresString += GameModel.teamScoreList[i];
			endScoresString += "\n----------------\n\n\n";
		}
		endScoresText.GetComponent<Text>().text = endScoresString;
	}

	public void EndTheGame() {

        GameModel.questionIndicesUsed.Clear();
        SceneManager.LoadScene("start_scene");
	}
}
