namespace Homework4.operations; 

public class Mutliplication : Operation, IBinaryOperation {
    
    public Mutliplication() : base("Mutliplication", "*", "Multiply two numbers") { }
    
    public double Calculate(double lhs, double rhs) {
        return lhs * rhs;
    }
    
}