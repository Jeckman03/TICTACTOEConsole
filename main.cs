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

			gameBoard = human.TurnChoice(input, gameBoard);

			gameBoard.DisplayGameBoard().PrintToConsole();

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
	GameBoard TurnChoice(string choice, GameBoard board);
}

// HumanPlayerClass
public class HumanPlayer : GameBoard, Players
{
	public string Name { get; set; }

	public GameBoard TurnChoice(string choice, GameBoard board)
	{
		for (var i = 0; i < board.squares.Length; i++)
		{
			if (choice == board.squares[i])
			{
				board.squares[i] = "X";
			}
		}

		return board;
	}
}

// ComputerPlayerClass
public class ComputerPlayer : GameBoard, Players
{
	public string Name { get; set; }

	public GameBoard TurnChoice(string choice, GameBoard board)
	{
		GameBoard output = new GameBoard();

		for (var i = 0; i < board.squares.Length; i++)
		{
			if (choice == board.squares[i])
			{
				board.squares[i] = "O";
			}
		}

		return board;
	}
} 

// GameBoardClass
public class GameBoard 
{
	
	public string[] squares = new string[9]
	{
		"1", 
		"2", 
		"3",
		"4", 
		"5", 
		"6", 
		"7",
		"8",
		"9"
	};

	

	public string DisplayGameBoard()
	{
		return $@"
		  { squares[0] }  |  { squares[1] }  |  { squares[2] }
		_____|_____|_____
		  { squares[3] }  |  { squares[4] }  |  { squares[5] }
		_____|_____|_____
		  { squares[6] }  |  { squares[7] }  |  { squares[8] }
			 |     |";
	}


}


