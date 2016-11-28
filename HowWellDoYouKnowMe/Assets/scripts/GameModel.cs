using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModel {
	public static int numberOfTeams;
	public static int[] teamScoreList; 
	public static int currentTeam = 0;
	public static int currentPlayer = 0;
	public static int totalRounds = 3; //TODO: make this customizable.
	public static int currentRound = 0;
	public static Camera camera;
	public static int questionAnswer;
	public static string turn;
	public static List<int> questionIndicesUsed = new List<int>();

	public static List<Question> questionsList = new List<Question>() {
		new Question(
			"What color do you like most?",
			new string[] {"Red", "Yellow ", "Blue", "Black"}),
		new Question(
			"Which landscape would you rather be in?",
			new string[] {"Mountains", "Beach", "Downtown"}),
		new Question(
			"Which movie genre do you prefer?",
			new string[] {"Romance", "Action", "Comedy", "Documentary"}),
		new Question(
			"Which music genre do you prefer?",
			new string[] {"Rock", "Country", "Pop", "Rap"}),
		new Question(
			"What US State would you rather live in?",
			new string[] {"California", "New York", "Texas", "Alaska"}),
		new Question(
			"Which sport do you like more?",
			new string[] {"Baseball", "Basketball", "Football"}),
		new Question(
			"What vacation type would you prefer?",
			new string[] {"Cruise", "Stay-cation", "Camping"}),
		new Question(
			"Which cereal do you prefer?",
			new string[] {"Frosted Flakes", "Honey Nut Cheerios", "Lucky Charms"}),
		new Question(
			"Which side dish do you prefer for a holiday feast?",
			new string[] {"Mashed Potatoes", "Green Bean Casserole", "Stuffing", "Corn"}),
		new Question(
			"What is your go-to gift wrapping strategy?",
			new string[] {"Wrapping Paper", "Gift Bag", "Handcrafted Gift Box", "Grocery Store Bag"}),
		new Question(
			"What is your preferred PC Operating System",
			new string[] {"Windows", "Mac", "Linux", "What’s an Operating System?"}),
		new Question(
			"What is your preferred Pie Filling?",
			new string[] {"Apple", "Chocolate", "Pumpkin", "Berry"}),
		new Question(
			"What is your favorite winter sport?",
			new string[] {"Skiing", "Snowboarding", "Snowshoeing", "Drinking Hot Chocolate"}),
		new Question(
			"What is your preferred form of exercise",
			new string[] {"Bike", "Run", "Walk", "Exercise?"}),
		new Question(
			"What is your preferred berry flavor?",
			new string[] {"Strawberry", "Blueberry", "Blackberry", "Raspberry"}),
		new Question(
			"What kind of vehicle would you rather have?",
			new string[] {"Car", "Truck", "SUV", "Motorcycle"}),
		new Question(
			"Which brand of truck do you prefer?",
			new string[] {"Ford", "Chevy", "Dodge", "Toyota"}),
		new Question(
			"GameModel.Which brand of sports car do you prefer?",
			new string[] {"Ferrari", "Lamborghini", "Porsche", "Aston Martin"}),
		new Question(
			"Which brand of luxury car do you prefer?",
			new string[] {"BMW", "Mercedes", "Lexus", "Audi"}),
		new Question(
			"Which flavor of ice cream do you prefer?",
			new string[] {"Vanilla", "Strawberry", "Chocolate", "Rocky Road"}),
		new Question(
			"Which pet do you prefer to have?",
			new string[] {"Dog", "Cat", "Fish", "Bird"}),
		new Question(
			"How would you rather travel a long distance?",
			new string[] {"Train", "Plane", "Ship", "Car"}),
		new Question(
			"Which type of pizza do prefer?",
			new string[] {"Pepperoni", "Cheese", "Veggie", "Supreme"}),
		new Question(
			"Which comedian do you like better?",
			new string[] {"Drew Carrey", "Jeff Foxworthy ", "Seinfeld", "Jim Gaffigan"}),
		new Question(
			"Which exercise type do you prefer?",
			new string[] {"Crossfit", "Jazzercise ", "Pilates", "Weightlifting"}),
		new Question(
			"How many children do you want?",
			new string[] {"0", "1 ", "2", "3+"}),
		new Question(
			"What kind of dog do you want?",
			new string[] {"Big Dog", "Little Dog ", "Giant Dog", "No Dog"}),
	};

}
