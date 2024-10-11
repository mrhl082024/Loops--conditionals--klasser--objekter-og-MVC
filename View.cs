public class View
{
    public void DisplayGames(List<VideoGame> videoGames)
    {
        foreach (var VideoGame in videoGames)
        {
            Console.WriteLine(VideoGame);
        }
    }

    public void ShowMessage (String message)
    {
        Console.WriteLine(message);
    }

    public void ShowMenu()
    {
        Console.WriteLine("\nWelcome to my game list");
        Console.WriteLine("\nWhat do you want to do?");
        Console.WriteLine("Write 1 to display the list of games");
        Console.WriteLine("Write 2 to add a new game to the list");
        Console.WriteLine("Write 3 to change the details of a game");
        Console.WriteLine("Write 4 to remove a game");
        Console.WriteLine("Write 5 to exit the program");
    }

    public void ShowUpdateMenu()
    {
        Console.WriteLine("\nWhat do you want to update?");
        Console.WriteLine("Write 1 to update Title");
        Console.WriteLine("Write 2 to update Release Year");
        Console.WriteLine("Write 3 to update Genre");
    }

}