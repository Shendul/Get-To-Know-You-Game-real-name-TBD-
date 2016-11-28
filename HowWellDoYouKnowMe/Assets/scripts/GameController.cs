using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public void HandleButtonPress (int buttonNum) {
		Debug.Log ("Button: " + buttonNum + " Pressed");
		bool roundOver = false;
		if (GameModel.turn == "A")
		{
			GameModel.turn = "Q";
			if (AnswerMatches(buttonNum))
			{
				// TODO: Show win screen briefly and play correct sound.
				GameModel.teamScoreList[GameModel.currentTeam] += 1;
			} else {
				//TODO: Show fail screen briefly and play fail sound.
			}
			if (GameModel.currentTeam == (GameModel.numberOfTeams - 1) && 
			    GameModel.currentRound <= GameModel.totalRounds){
				GameModel.currentTeam = 0;
				roundOver = true;
				//TODO: show scores.

				if (GameModel.currentRound == (GameModel.totalRounds)){
					Application.LoadLevel("end_game_scene");
				} else {
					Application.LoadLevel("score_scene");
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
			GameModel.questionAnswer = buttonNum;
			//UpdateUIForNextTurn();
		}
	}

	private void UpdateUIForNextTurn (){
		// initialize the question.
		int nextQuestionIndex = Random.Range (0,GameModel.questionsList.Count);
		while (GameModel.questionIndicesUsed.Contains(nextQuestionIndex)){
			// reroll.
			nextQuestionIndex = Random.Range (0,GameModel.questionsList.Count);
		}
		GameModel.questionIndicesUsed.Add(nextQuestionIndex);
		//TODO: make sure the questionIndicesUsed resets after a game.

		Question currentQuestion = GameModel.questionsList[nextQuestionIndex];
		Debug.Log ("Current Turn: " + GameModel.turn);
		//TODO: RANDOMIZE BUTTONS LOCATIONS
		descriptionText.GetComponent<Text>().text = currentQuestion.description;

		if (currentQuestion.answers.Length > 3) {

			button3.GetComponentInChildren<Text>().text = currentQuestion.answers[3];
		}
		button0.GetComponentInChildren<Text>().text = currentQuestion.answers[0];
		button1.GetComponentInChildren<Text>().text = currentQuestion.answers[1];
		button2.GetComponentInChildren<Text>().text = currentQuestion.answers[2];
	}

	private bool AnswerMatches (int buttonNum) {
		return buttonNum == GameModel.questionAnswer;		
	}
}
