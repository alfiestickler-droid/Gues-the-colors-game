//colors for guessing
string red = "red";
string blue = "blue";
string green = "green";
string yellow = "yellow";
string black = "black";
string white = "white";

//array of colors for sequence
string[] listOfColours = [red, blue, green, yellow, black, white];

string[] secretOrder = GetRandomSequence();



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

    Console.WriteLine("Pick 4 colours out of red, blue, green, yellow, black or white.\n ");

    for(int i = 4; i >= 0; --i)
    {
        switch (i)
        {
            case 4:
                Console.WriteLine("Enter your first color");
                Console.ReadLine();
                break;

            case 3:
                Console.WriteLine("Enter your second color");
                Console.ReadLine();
                break;

            case 2:
                Console.WriteLine("Enter your thrid color");
                Console.ReadLine();
                break;

            case 1:
                Console.WriteLine("Enter your final color");
                Console.ReadLine();
                break;
        }
    }

    return guesses;
}

string[] GetRandomSequence()
{

    string[] secretOrder = ["color", "color", "color", "color"];

    for(int i = 0; i < 4; i++)
    {
        int arrayColor = Random.Shared.Next(1, 7);
        int colorPicker = arrayColor;

        string randomColor = listOfColours[colorPicker];

        secretOrder[i] = randomColor;
    }
    return secretOrder;
}

//Bool CompareGuessToSequence()
