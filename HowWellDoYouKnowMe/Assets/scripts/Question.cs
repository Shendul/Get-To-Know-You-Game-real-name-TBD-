using UnityEngine;
using System.Collections;

public class Question {
	public string description;
	public string[] answers;

	public Question(string description, string[] answers) {
		this.description = description;
		this.answers = answers;
	}
}
