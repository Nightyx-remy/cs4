namespace Homework4; 

public class Controller {
    
    public IMenu Menu { get; set; }
    public List<IExpressionEvaluator> Evaluators { get; } = new();
    private IExpressionEvaluator _currentEvaluator;

    private IExpressionEvaluator CurrentEvaluator {
        get => _currentEvaluator;
        set {
            Menu.Help = value.Help;
            _currentEvaluator = value;
        }
    }
    
    public Controller(IMenu menu, IEnumerable<IExpressionEvaluator> evaluator) {
        Menu = menu;
        Evaluators.AddRange(evaluator);
        CurrentEvaluator = Evaluators.First();
    }

    private void SwitchEvaluator() {
        var index = 1;
        foreach (var evaluator in Evaluators) {
            Console.Out.WriteLine($"{index}) {evaluator.Description}");
            index += 1;
        }

        var input = Console.ReadLine();
        while (true) {
            try {
                var value = Convert.ToInt16(input);
                if (value <= 0 || value > Evaluators.Count) continue;
                CurrentEvaluator = Evaluators[value - 1];
                break;
            } catch (Exception _) {
                // ignored
            }
        }
    }

    public void Run() {
        Menu.ShowMenu();
        
        string input;
        while (true) {
            Console.Out.Write(">> ");
            input = Console.ReadLine() ?? "exit";
            
            switch (input) {
                case "exit":
                    goto EOL;
                case "help":
                    Menu.ShowHelp();
                    break;
                case "evaluator":
                    SwitchEvaluator();
                    break;
                default:
                    try {
                        var result = _currentEvaluator.Evaluate(input);
                        Console.Out.WriteLine($"result: {result}");
                    } catch (Exception e) {
                        Console.Out.WriteLine($"{e.Message}");
                    }
                    Console.Out.WriteLine("");
                    break;
            }
        }
        
        EOL: Console.Out.WriteLine("Bye...");
    }
    
}