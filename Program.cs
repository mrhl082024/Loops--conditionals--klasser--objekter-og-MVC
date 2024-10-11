namespace Loops__conditionals__klasser__objekter_og_MVC;

class Program
{
    static void Main(string[] args)
    {
    
        Model model = new Model();
        View view = new View();
        Controller controller = new Controller(model, view);

 
        controller.Run();
    }
}