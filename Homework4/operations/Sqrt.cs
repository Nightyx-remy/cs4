namespace Homework4.operations; 

public class Sqrt : Operation, IUnaryOperation {

    public Sqrt() : base("Square root", "sqrt", "Calculate the square root of a number") {
        
    }
    
    public double Calculate(double operand) {
        return Math.Sqrt(operand);
    }
}