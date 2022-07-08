namespace Homework4.rpn; 

public class RPNEvaluator : IExpressionEvaluator {

    public ICalculator Calculator { get; set; }
    public IParser Parser { get; set; }

    public RPNEvaluator(ICalculator calculator, IParser parser) {
        Parser = parser;
        Parser.SupportedOperators = calculator.SupportedOperators;
        Calculator = calculator;
    }
    
    public double Evaluate(string expression) {
        var parsed = Parser.Tokenize(expression);
        var tokens = Parser.Lex(parsed);
        return Calculator.Calculate(tokens);
    }

    public IList<string> Help => Calculator.OperationsHelpText;

    public string Description => "Reverse Polish Notation Calculator";

}