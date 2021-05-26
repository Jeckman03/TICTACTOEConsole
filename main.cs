using System;

class MainClass {
  public static void Main (string[] args) {

		// Populate the empty game board
		GameBoard gameBoard = new GameBoard();
		gameBoard.DisplayGameBoard().PrintToConsole();

		// Create both players
		HumanPlayer human = new HumanPlayer();
		human.Name = "Jeff";
		ComputerPlayer computer = new ComputerPlayer();
		computer.Name = "Compuserve";

		bool gameOver = false;

		// While game is still going
		while (!gameOver)
		{
			// Human players turn
			human.PlayerTurn();
			string input = Console.ReadLine();
			bool isValid = GameLogic.IsValidSelection(input);

			if (isValid)
			{
				Console.WriteLine("You have made a valid selection");
			}
			else
			{
				Console.WriteLine("You have made an invalid selection. Try again");
			}

			// Check to see if there is a winner
			//Check to see if there is any open spots left

			// Computer players turn 

			// Check to see if there is a winner
			//Check to see if there is any open spots left

			Console.ReadLine();
		}
			

    Console.ReadLine();
  }
}

public static class ConsoleHelper
{
	public static void PrintToConsole(this string message)
	{
		Console.WriteLine(message);
	}

	public static void PlayerTurn(this Players player)
	{
		Console.WriteLine($"It's { player.Name } turn!");
		Console.Write("Type the number of the square you would like to claim: ");
	}
}

public static class GameLogic
{
	public static bool IsValidSelection(string selection)
	{
		bool isValid = Int32.TryParse(selection, out int number);

		if (isValid && number < 10 && number > 0)
		{
			return true;
		}

		return false;
	}
}

// TIC TAC TOE

// Player vs Comp
// Take turns selecting a square
// Once someone has connected three in a row they win 
// Or it will be a draw

// Player Interface
public interface Players
{
	string Name { get; set; }
	void TurnChoice();
}

// HumanPlayerClass
public class HumanPlayer : Players
{
	public string Name { get; set; }

	public void TurnChoice(string numberChoice, GameBoard board)
	{

	}
}

// ComputerPlayerClass
public class ComputerPlayer : Players
{
	public string Name { get; set; }

	public void TurnChoice()
	{

	}
} 

// GameBoardClass
public class GameBoard 
{
	public string one = "1";
	public string two = "2";
	public string three = "3";
	public string four = "4";
	public string five = "5";
	public string six = "6";
	public string seven = "7";
	public string eight = "8";
	public string nine = "9";


	public string DisplayGameBoard()
	{
		return $@"
		  { one }  |  { two }  |  { 3 }
		_____|_____|_____
		  { four }  |  { five }  |  { six }
		_____|_____|_____
		  { seven }  |  { eight }  |  { nine }
			 |     |";
	}


}


