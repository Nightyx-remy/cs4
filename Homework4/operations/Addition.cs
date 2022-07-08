namespace Homework4.operations; 

public class Addition : Operation, IBinaryOperation {
    
    public Addition() : base("Addition", "+", "Add two numbers") { }
    
    public double Calculate(double lhs, double rhs) {
        return lhs + rhs;
    }
    
}