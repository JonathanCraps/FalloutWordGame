internal class Program
{
    private static void Main(string[] args)
    {
        string[] words =
        {
            "SHOW", "READ", "LIFE", "MAIN", "ONLY", "LOVE", "MOVE", "WIFE", "LEAD", "BLOW", "DAZE", "DOOR", "CORE", "RING", "SING", "SINE"
        };
        string[] unpickedWords = words;
        Random rnd = new Random();
        int passwordIndex = rnd.Next(0, words.Length - 1);
        int attemptsLeft = 4;
        bool spelBezig = true;
        while (spelBezig == true)
        {
            PrintPage(ref unpickedWords, ref attemptsLeft);
            PickNumber(ref unpickedWords, ref words, ref passwordIndex, ref attemptsLeft, ref spelBezig);
        }
        if (attemptsLeft <= 0)
        {
            Console.Clear();
            Console.WriteLine("You lost, the password was {0}", words[passwordIndex]);
            spelBezig = false;

        }
    }
    private static void PrintPage(ref string[] unpickedWords, ref int attemptsLeft)
    {
        //PrintLogic
        Console.Clear();
        Console.Write("Please Type in the number for the correct password ");
        int attemptTeller = 0;
        Console.WriteLine("\n   ");
        for (int i = 0; i < 4; i++)
        {
            if (attemptTeller < attemptsLeft)
            {
                Console.Write(" %");
                attemptTeller++;
            }
            else
            {
                Console.Write(" .");
            }
        }
        Console.Write(" left.");
        Console.WriteLine("\n ______________________________________________________________________");
        int counter = 0;
        foreach (string word in unpickedWords)
        {
            Console.WriteLine("{0}) {1}", counter, word);
            counter++;
        }
    }
    private static void PickNumber(ref string[] unpickedWords, ref string[] words, ref int passwordIndex, ref int attemptsLeft, ref bool spelBezig)
    {
        int pickedChoice = int.Parse(Console.ReadLine());
        while (pickedChoice < 0 || pickedChoice > unpickedWords.Length)
        {
            pickedChoice = int.Parse(Console.ReadLine());
        }
        int similarity = 0;
        for (int i = 0; i < 4; i++)
        {
            if (words[pickedChoice][i] == words[passwordIndex][i])
            {
                similarity++;
            }
        }

        if (pickedChoice != passwordIndex)
        {
            attemptsLeft--;
            unpickedWords[pickedChoice] += "( SIMILARITY:" + similarity + ")";
            Console.WriteLine("Similarity: {0}", similarity);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("The password was {0}", words[passwordIndex]);
            spelBezig = false;
        }
    }
}