namespace Homework4.operations; 

public class Division : Operation, IBinaryOperation {
    
    public Division() : base("Division", "/", "Divide two numbers") { }
    
    public double Calculate(double lhs, double rhs) {
        return lhs / rhs;
    }
    
}