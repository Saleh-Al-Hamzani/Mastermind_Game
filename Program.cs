using System;
using System.Linq;
using System.Collections.Generic;
// This program implements a simple Mastermind game where the player has to guess a secret code.
public class Program
{
    public static void Main(string[] args)
    {
        string SecretCode = "";
        int maxAttempts =10;
        MastermindGame game;
        // Parse command line args
        for (int i = 0; i < args.Length; i++)
        {
            //handel the -c command
            if (args[i] == "-c" && i + 1 < args.Length)
            {
                if (!new Code().IsValidInput(args[i + 1]))
                {
                    Console.WriteLine("Invalid secret code! Must be 4 digits from 0 to 8.");
                    return;
                }
                SecretCode = args[i + 1];
                i++;
            }
            //handel the -t command
            else if (args[i] == "-t" && i + 1 < args.Length)
            {
                if (!int.TryParse(args[i + 1], out maxAttempts))
                {
                    Console.WriteLine("Invalid number of attempts. Must be an integer.");
                    return;
                }
                i++;
            }
        }
        Console.WriteLine("\nCtrl + Z then enter to exit the game");
        Console.WriteLine("Can you break the code? Enter a valid guess. Must be 4 digits from 0-8:");
        //genrate code if there no -c command
        if (args.Length == 0 || !args.Contains("-c"))
        {
            game = new MastermindGame(0, maxAttempts);
            game.StartGame();
        }
        else
        {
            game = new MastermindGame(0, maxAttempts, SecretCode);
            game.StartGame();
        }
    }
}
//handel the Mastermind game logic including user prompts, guesses, and game state.
public class MastermindGame
{
    private GameSettings gameSettings;
    private Code code;
    public MastermindGame(int numOfAttempts, int maxAttempts)
    {
        gameSettings = new GameSettings(numOfAttempts, maxAttempts);
        code = new Code();
    }
    public MastermindGame(int numOfAttempts, int maxAttempts, string secretCode)
    {
        gameSettings = new GameSettings(numOfAttempts, maxAttempts);
        code = new Code();
        code.SetSecretCode(secretCode);
    }
    public void StartGame()
    {
        while (!gameSettings.IsGameOver())
        {
            
            Console.WriteLine("\nRound " + gameSettings.GetNumberOfAttempts());
            string guess = Console.ReadLine();
            if (guess == null)
            {
                Console.WriteLine("Exiting game.");
                return;
            }
            if (code.IsValidInput(guess))
            {
                
                int correctPositions = code.CountCorrectPositions(guess);
                int misplacedPieces = code.CountMisplacedPieces(guess);
                if (correctPositions == 4)
                {
                    Console.WriteLine("Congratz! You did it!");
                    return;
                }
                else
                {
                    Console.WriteLine("Well-placed pieces: " + correctPositions);
                    Console.WriteLine("Misplaced pieces: " + misplacedPieces);
                    gameSettings.IncrementAttempts();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a 4-digit code using digits from 0 to 8.");
            }
        }
        Console.WriteLine("Game over! You've used all attempts.");
    } 
}
// This class handles the game settings, including the number of attempts and maximum attempts allowed.
public class GameSettings{
    private int numberOfAttempts = 0;
    private int maxAttempts = 10;

    public GameSettings(int numofAttempts,int maxAtt){
        numberOfAttempts = numofAttempts;
        maxAttempts = maxAtt;
    }
    public bool IsGameOver()
    {
        return numberOfAttempts >= maxAttempts;
    }
    public int GetNumberOfAttempts()
    {
        return numberOfAttempts;
    }
    public int GetMaxAttempts()
    {
        return maxAttempts;
    }
    public void IncrementAttempts()
    {
        numberOfAttempts++;
    }
   
}
// This class generates a random 4-digit code and provides methods to validate input, count misplaced pieces, and count correct positions.
public class Code
{
    private string SecretCode;
     public Code()
    {
        SetSecretCode(GenerateRandomCode());
    }
    public bool IsValidInput(string input)
    {
        if (input.Distinct().Count() != 4) return false;
        if (input.Length != 4) return false;
        foreach (char c in input)
        {
            if (!char.IsDigit(c) || c < '0' || c > '8') return false;
        }
        return true;
    }
    public string GenerateRandomCode()
    {
        Random random = new Random();
        HashSet<int> usedDigits = new HashSet<int>();
        string code = "";

        while (code.Length < 4)
        {
            int digit = random.Next(0, 9); // 0 to 8 inclusive
            if (!usedDigits.Contains(digit))
            {
                usedDigits.Add(digit);
                code += digit.ToString();
            }
        }

        return code;
    }
    public string GetSecretCode()
    {
        return SecretCode;
    }
    public void SetSecretCode(string code)
    {
        SecretCode = code;
    }
    public int CountMisplacedPieces(string GuessCode)
    {
        int misplaced = 0;
        bool[] codeUsed = new bool[4];
        bool[] guessUsed = new bool[4];

        // check to see the ones that in right place 
        for (int i = 0; i < 4; i++)
        {
            if (GuessCode[i] == GetSecretCode()[i])
            {
                codeUsed[i] = true;
                guessUsed[i] = true;
            }
        }

        // Now find misplaced ones
        for (int i = 0; i < 4; i++)
        {
            if (guessUsed[i]) continue;

            for (int j = 0; j < 4; j++)
            {
                if (!codeUsed[j] && GuessCode[i] == GetSecretCode()[j])
                {
                    misplaced++;
                    codeUsed[j] = true;
                    break;
                }
            }
        }

        return misplaced;
    }
    public int CountCorrectPositions(string GuessCode)
    {
        int correct = 0;
        string code = GetSecretCode();

        for (int i = 0; i < 4; i++)
        {
            if (GuessCode[i] == code[i])
            {
                correct++;
            }
        }
        return correct;
    }
}
