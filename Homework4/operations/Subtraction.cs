namespace Homework4.operations; 

public class Subtraction : Operation, IBinaryOperation {
    
    public Subtraction() : base("Subtraction", "-", "Subtract two numbers") { }
    
    public double Calculate(double lhs, double rhs) {
        return lhs - rhs;
    }
    
}