public class Controller
{
    private Model model;
    private View view;

    public Controller(Model model, View view)
    {
        this.model = model;
        this.view = view;
    }

    public void Run()
    {
        bool exit = false;

        while(!exit)
        {
            view.ShowMenu();

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    view.ShowMessage("\n");
                    view.DisplayGames(model.GetGames());
                    break;

                case "2":
                    view.ShowMessage("\n");
                    AddGame();
                    break;

                case "3":
                    view.ShowMessage("\n");
                    UpdateGame();
                    break;

                case "4":
                    view.ShowMessage("\n");
                    RemoveGame();
                    break;

                case "5":
                    exit = true;
                    view.ShowMessage("Exiting program...");
                    break;

                default:
                    view.ShowMessage("Invalid choice, please try again");
                    break;
            }
        }
    }
    // Add Game
    private void AddGame()
    {
        view.ShowMessage("\n");
        view.ShowMessage("Enter the game's title");
        string? title = Console.ReadLine();

        while(string.IsNullOrEmpty(title))
        {
            view.ShowMessage("Title can not be empty");
            title = Console.ReadLine();
        }

        view.ShowMessage("\n");
        view.ShowMessage("Enter the game's release year");

        string? yearInput = Console.ReadLine();
        int year;
        while(!int.TryParse(yearInput, out year))
        {
            view.ShowMessage("There was an error with the data submitted, please input the year using numbers");
            yearInput = Console.ReadLine();
        }

        view.ShowMessage("\n");
        view.ShowMessage("Enter the game's genre");
        string? genre = Console.ReadLine();
        while(string.IsNullOrEmpty(genre))
        {
            view.ShowMessage("Genre can not be empty");
            genre = Console.ReadLine();
        }

        model.AddGame(title, year, genre);
        view.ShowMessage("\n");
        view.ShowMessage("Displaying updated list:");
        view.DisplayGames(model.GetGames());
    }
    // Remove game
    private void RemoveGame()
    {
        view.ShowMessage("Please enter the title of the game you wish to remove");
        string? title = Console.ReadLine();

        if (string.IsNullOrEmpty(title))
        {
            view.ShowMessage("Title can not be empty");
            return;
        }

        if(model.RemoveGame(title))
        {
            view.ShowMessage("\n");
            view.ShowMessage($"Game {title} removed successfully.");
        }
        else
        {
            view.ShowMessage("\n");
            view.ShowMessage($"Game {title} not found");
        }
        view.ShowMessage("Displaying updated list:");
        view.DisplayGames(model.GetGames());
    }

    // Update Title, Year or Genre
    private void UpdateGame()
    {
        view.ShowMessage("\n");
        view.ShowMessage("Enter the title of the game to update");
        string? title = Console.ReadLine();

        if (string.IsNullOrEmpty(title))
        {
            view.ShowMessage("title can not be empty");
            return;
        }
        else 
        {
            view.ShowUpdateMenu();

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1": 
                    view.ShowMessage("\n");
                    view.ShowMessage("Enter the new title for the game");

                    string? newTitle = Console.ReadLine();

                    if (string.IsNullOrEmpty(newTitle))
                    {
                        view.ShowMessage("New Title can not be empty");
                        return;
                    }
                    model.UpdateGameTitle(title, newTitle);
                    view.ShowMessage("\n");
                    view.ShowMessage("Displaying updated list:");
                    view.DisplayGames(model.GetGames());
                    break;

                case "2": 
                    view.ShowMessage("\n");
                    view.ShowMessage("Enter the new Release Year for the game");

                    string? yearInput = Console.ReadLine();
                    int newYear;

                    if(string.IsNullOrEmpty(yearInput))
                    {
                        view.ShowMessage("New Release Year can not be empty");
                        return;
                    }
                    else 
                    {
                        while(!int.TryParse(yearInput, out newYear))
                        {
                            view.ShowMessage("There was an error with the data submitted, please input the year using numbers");
                            yearInput = Console.ReadLine();
                        }
                    }
                    model.UpdateGameYear(title, newYear);
                    view.ShowMessage("\n");
                    view.ShowMessage("Displaying updated list:");
                    view.DisplayGames(model.GetGames());
                    break;

                case "3": 
                    view.ShowMessage("\n");
                    view.ShowMessage("Enter the new Genre for the game");

                    string? newGenre = Console.ReadLine();

                    if(string.IsNullOrEmpty(newGenre))
                    {
                        view.ShowMessage("New Release Year can not be empty");
                        return;
                    }
                    model.UpdateGameGenre(title, newGenre);
                    view.ShowMessage("\n");
                    view.ShowMessage("Displaying updated list:");
                    view.DisplayGames(model.GetGames());
                    break;

                default:
                    view.ShowMessage("\n");
                    view.ShowMessage("Invalid choice, please try again");
                    break;
            }
        }
    }

}