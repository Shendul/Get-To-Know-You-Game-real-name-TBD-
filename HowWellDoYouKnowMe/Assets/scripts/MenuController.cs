using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public Slider numOfTeamsSlider;
    public Slider numOfRoundsSlider;
    public GameObject popUpCanvas;
    public InputField numOfTeamsAboveFour;
    public Text popUpText;

    // Use this for initialization
    public void StartGame()
    {
        if (numOfTeamsSlider.value <= 4) { 
            GameModel.numberOfTeams = (int)numOfTeamsSlider.value;
            GameModel.totalRounds = (int)numOfRoundsSlider.value;
            Debug.Log(GameModel.numberOfTeams);
            GameModel.teamScoreList = new int[GameModel.numberOfTeams];
            GameModel.currentRound = 1;
            SceneManager.LoadScene("game_scene");
            GameModel.turn = "Q";
        } else {
            popUpCanvas.SetActive(true);
            Debug.Log("Brought in pop up window");
        }
	}

    // Use this for explaining how to play the game.
    public void HowToPlay()
    {
        Debug.Log("Entering game explanation page");
        SceneManager.LoadScene("how_to_play_scene");
    }

    // Use this to bring back the start menu.
    public void MainMenu()
    {
        Debug.Log("Returning to Main Menu");
        SceneManager.LoadScene("start_scene");
    }

    // Use this for explaining how to play the game.
    public void ClosePopUpWindow()
    {
        if (int.Parse(numOfTeamsAboveFour.text) >= 5) {
            Debug.Log("Closing Pop Up");
            Debug.Log("Number of Teams = " + int.Parse(numOfTeamsAboveFour.text));
            popUpCanvas.SetActive(false);
            popUpText.text = "How many teams of two will be playing?";

            // Also start the game.
            GameModel.numberOfTeams = int.Parse(numOfTeamsAboveFour.text);
            GameModel.totalRounds = (int)numOfRoundsSlider.value;
            Debug.Log(GameModel.numberOfTeams);
            GameModel.teamScoreList = new int[GameModel.numberOfTeams];
            GameModel.currentRound = 1;
            SceneManager.LoadScene("game_scene");
            GameModel.turn = "Q";

        } else {
            Debug.Log("Invalid num");
            popUpText.text = "Invalid Num: Must be higher than 4";
        }
    }


    // Update is called once per frame
    void Update () {
	}
}
