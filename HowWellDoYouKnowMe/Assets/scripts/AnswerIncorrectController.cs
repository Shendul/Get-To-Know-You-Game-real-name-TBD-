using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerIncorrectController : MonoBehaviour {

    public AudioSource errorSound;
    public GameObject scoresText;

    // Use this for initialization
    void Start()
    {
        errorSound.Play();
        string scoresString = "Your Answers did not Match!\n\n";
        for (int i = 0; i < GameModel.numberOfTeams; i++)
        {
            scoresString += "Team " + i + "'s Score: ";
            scoresString += GameModel.teamScoreList[i];
            scoresString += "\n----------------\n\n\n";
        }
        scoresText.GetComponent<Text>().text = scoresString;
    }

    public void StartNextRound()
    {
        SceneManager.LoadScene("game_scene");
        GameModel.turn = "Q";
    }
}
