using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public GameObject button0;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject descriptionText;

	// Use this for initialization
	void Start () {
		UpdateUIForNextTurn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Logic to handle button presses
	public void HandleButtonPress (GameObject buttonText) {
		Debug.Log ("Button: " + buttonText + " Pressed");
		bool roundOver = false;
        string buttonString = buttonText.GetComponent<Text>().text;
        if (GameModel.turn == "A")
		{
			GameModel.turn = "Q";
			if (AnswerMatches(buttonString))
			{
				// TODO: maybe fix the end round overriding this score screen
				GameModel.teamScoreList[GameModel.currentTeam] += 1;
                SceneManager.LoadScene("answered_correctly_scene");
            } else {
                //TODO: maybe fix the end round overriding this score screen
                SceneManager.LoadScene("answered_incorrectly_scene");

            }
			if (GameModel.currentTeam == (GameModel.numberOfTeams - 1) && 
			    GameModel.currentRound <= GameModel.totalRounds){
				GameModel.currentTeam = 0;
				roundOver = true;

				if (GameModel.currentRound == (GameModel.totalRounds)){
                    SceneManager.LoadScene("end_game_scene");
				} else {
                    SceneManager.LoadScene("score_scene");
				}

			} else {
				GameModel.currentTeam++;
            }
			if (roundOver){
				UpdateUIForNextTurn();
				roundOver = false;
			}

			if (GameModel.currentPlayer == 1) {
				GameModel.currentPlayer = 0;
			} else {
				GameModel.currentPlayer = 1;
			}
		}
		else
		{
			if (GameModel.currentPlayer == 0) {
				GameModel.currentPlayer = 1;
			}
			else {
				GameModel.currentPlayer = 0;
			}
			GameModel.turn = "A";
			GameModel.questionAnswer = buttonString;
			UpdateUIForNextTurn();
		}
	}

	private void UpdateUIForNextTurn (){

        if (GameModel.turn == "Q")
        {
            // initialize the question.
            int nextQuestionIndex = Random.Range(0, GameModel.questionsList.Count);
            while (GameModel.questionIndicesUsed.Contains(nextQuestionIndex))
            {
                // reroll.
                nextQuestionIndex = Random.Range(0, GameModel.questionsList.Count);
            }
            GameModel.questionIndicesUsed.Add(nextQuestionIndex);
            GameModel.currentQuestion = GameModel.questionsList[nextQuestionIndex];
            Debug.Log("Current Turn: " + GameModel.turn);
            descriptionText.GetComponent<Text>().text = GameModel.currentQuestion.description;
        }
        //used to generate a random list of answers
        for (int t = 0; t < GameModel.currentQuestion.answers.Length; t++)
        {
            string tmp = GameModel.currentQuestion.answers[t];
            int r = Random.Range(t, GameModel.currentQuestion.answers.Length);
            GameModel.currentQuestion.answers[t] = GameModel.currentQuestion.answers[r];
            GameModel.currentQuestion.answers[r] = tmp;
        }

        if (GameModel.currentQuestion.answers.Length > 3) {
			button3.GetComponentInChildren<Text>().text = GameModel.currentQuestion.answers[3];
		} else { button3.gameObject.SetActive(false); }
		button0.GetComponentInChildren<Text>().text = GameModel.currentQuestion.answers[0];
		button1.GetComponentInChildren<Text>().text = GameModel.currentQuestion.answers[1];
		button2.GetComponentInChildren<Text>().text = GameModel.currentQuestion.answers[2];
	}

	private bool AnswerMatches (string buttonText) {
		return buttonText == GameModel.questionAnswer;		
	}
}
