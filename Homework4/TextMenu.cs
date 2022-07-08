namespace Homework4; 

public class TextMenu : IMenu {
    public IList<string> Help { get; set; }

    public void ShowMenu() {
        Console.Out.WriteLine("exit => exit the program");
        Console.Out.WriteLine("help => show the help menu");
        Console.Out.WriteLine("evaluator => switch evaluator");
        Console.Out.WriteLine("");
    }

    public void ShowHelp() {
        foreach (var op in Help) {
            Console.Out.WriteLine(op);
        }
        Console.Out.WriteLine("");
    }
    
}