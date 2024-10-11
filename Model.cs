public class VideoGame
{
    public string Title {get; set;}
    public int Year {get; set;}
    public string Genre {get; set;}

    public VideoGame(string title, int year, string genre)   
    {
        Title=title;
        Year=year;
        Genre=genre;
    }

    public override string ToString()
    {
        return $"Title: {Title}. Release year: {Year}. Genre: {Genre}";
    }
}

public class Model
{
    public List<VideoGame> VideoGames {get; set;}
    public Model ()
    {
        VideoGames = new List<VideoGame>
        {
        //Legg til spill her
        new VideoGame("Dark Souls", 2011, "Soulsborne, Difficult, Dark Fantasy")
        };
    }

    public void AddGame(string title, int year, string genre)
    {
        VideoGames.Add(new VideoGame(title, year, genre));
    }

    public bool RemoveGame(string title)
    {
        var gameToRemove = VideoGames.Find(g => g.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if(gameToRemove != null)
        {
            VideoGames.Remove(gameToRemove);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpdateGameTitle(string title, string newTitle)
    {
        var gameToUpdate = VideoGames.Find(g => g.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if(gameToUpdate != null)
        {
            gameToUpdate.Title = newTitle;
            return true;
        }
        else
        {
            return false;
        }
    }




}