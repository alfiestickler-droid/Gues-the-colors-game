using System.Linq;

bool exit = false;
bool win = false;
//colors for guessing
string red = "red";
string blue = "blue";
string green = "green";
string yellow = "yellow";
string black = "black";
string white = "white";

//array of colors for sequence
string[] listOfColours = [red, blue, green, yellow, black, white];

//main
do
{
    StartGame();
    string[] secretOrder = GetRandomSequence();

    for (int i = 9; i > 0; i--)
    {
        Console.WriteLine($"Guesses remaining {i}");
        string[] guesses = EnterGuesses();
        PrintGuesses(guesses);
        CompareGuessToSequence(guesses, secretOrder);
        if (win == true)
        {
            break;
        }

    }
    if (win == false)
    {
        Console.WriteLine($"Sorry you lose, the sequence was {string.Join(",", secretOrder)}");
    }

    PlayAgain();
} while (exit == false);


//end main

//functions

void StartGame()
{
    Console.Clear();
    Console.WriteLine("I am thinking of a sequence of 4 colors, you have 9 guesses to try and guess correctly\n");
    Console.WriteLine("Colours can be duplicated and the order must be correct\n");
    Console.WriteLine("After each guess I will tell you how many colours you have correct and if they are in the right position.");
}

string[] EnterGuesses()
{
    string[] guesses = new string[4];

    string[] orderWords = ["first", "second", "third", "final"];

    Console.WriteLine("\nPick 4 colors out of red, blue, green, yellow, black and white.\n");

    for (int i = 0; i < 4; i++)
    {
        Console.WriteLine($"Enter your {orderWords[i]} color:");

        guesses[i] = Console.ReadLine()?.ToLower().Trim();

        while (string.IsNullOrWhiteSpace(guesses[i]))
        {
            Console.WriteLine("No color entered, plaease pick red, blue, green, yellow, black or white");
            guesses[i] = Console.ReadLine()?.ToLower().Trim();
        }

        while (guesses[i] != "red" && guesses[i] != "blue" && guesses[i] != "green" && guesses[i] != "yellow" && guesses[i] != "black" && guesses[i] != "white")
        {
            Console.WriteLine("Invalid guess, please enter red, blue, green, yellow, black or white");
            guesses[i] = Console.ReadLine()?.ToLower().Trim();
        }
    }

    return guesses;
}

string[] GetRandomSequence()
{

    string[] secretOrder = ["color", "color", "color", "color"];

    for (int i = 0; i < 4; i++)
    {
        int arrayColor = Random.Shared.Next(0, listOfColours.Length);

        string randomColor = listOfColours[arrayColor];

        secretOrder[i] = randomColor;
    }
    return secretOrder;
}

void PrintGuesses(string[] guesses)
{

    string guessesPrint = string.Join(", ", guesses);

    Console.WriteLine($"\nYou entered: {guessesPrint}");

}

void CompareGuessToSequence(string[] guesses, string[] secretOrder)
{
    int correctColor = 0;
    int correctOrder = 0;
    



    for (int i = 0; i < 4; i++)
    {

        if (secretOrder[i] == guesses[i])
        {
            correctOrder++;
        }
    }
    if (correctOrder == 4)
    {
        Console.WriteLine($"Congratulations you win! the sequence was {string.Join(",", secretOrder)}");
        win = true;
    }
    else
    {
        Console.WriteLine($"{correctColor} of your guesses exist in the secret order.\n You have {correctOrder} colors in the correct position");
    }
}

void PlayAgain()
{
    Console.WriteLine("Would you like to play again (y/n)?");
    string userAnswer = Console.ReadLine().ToLower().Trim();

    while (userAnswer != "y" && userAnswer != "n")
    {
        Console.WriteLine("Sorry not a valid input, please enter y for yes or n for no.");
        userAnswer = Console.ReadLine().ToLower().Trim();
    }
    if (userAnswer == "n")
    {
        exit = true;
    }

}