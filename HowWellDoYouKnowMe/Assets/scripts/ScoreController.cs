using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

    public AudioSource errorSound;
    public AudioSource correctSound;
    public GameObject scoresText;

	// Use this for initialization
	void Start () {
        if (GameModel.answeredCorrectly) {
            correctSound.Play();
        } else {
            errorSound.Play();
        }
		string scoresString = "End of round " + GameModel.currentRound + ":\n\n";
		for (int i = 0; i < GameModel.numberOfTeams; i++){
			scoresString += "Team " + i + "'s Score: ";
			scoresString += GameModel.teamScoreList[i];
			scoresString += "\n----------------\n\n\n";
		}
		scoresText.GetComponent<Text>().text = scoresString;
	}
	
	public void StartNextRound () {
		GameModel.currentRound++;
        SceneManager.LoadScene("game_scene");
		GameModel.turn = "Q";
	}
}
