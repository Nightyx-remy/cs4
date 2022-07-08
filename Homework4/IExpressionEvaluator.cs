namespace Homework4; 

public interface IExpressionEvaluator {

    double Evaluate(string expression);
    
    IList<string> Help { get; }
    string Description { get; }

}