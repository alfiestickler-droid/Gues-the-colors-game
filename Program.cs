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

StartGame();
string[] secretOrder = GetRandomSequence();
string[] guesses = EnterGuesses();
PrintGuesses();
CompareGuessToSequence();

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

        while(string.IsNullOrWhiteSpace(guesses[i]))
        {
            Console.WriteLine("No color entered, plaease pick red, blue, green, yellow, black or white");
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

void PrintGuesses()
{
    
    string guessesPrint = string.Join(", ", guesses);

    Console.WriteLine($"\nYou entered: {guessesPrint}");

}

void CompareGuessToSequence()
{
    int correctColor = 0;
    int correctOrder = 0;

    for (int i = 0; i < 6; i++)
    {
        if (secretOrder.Contains(listOfColours[i]) && guesses.Contains(listOfColours[i]))
        {
            correctColor++;
        }
    }

    for (int i = 0; i < 4; i++)
    {
        
        if (secretOrder[i] == guesses[i])
        {
            correctOrder++;
        }
    }

    Console.WriteLine($"You have {correctColor} colors correct.\n You have {correctOrder} colors in the correct position");
}
