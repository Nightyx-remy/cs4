namespace Homework4.operations; 

public class Logarithm : Operation, IUnaryOperation {

    public Logarithm() : base("Logarithm", "ln", "Calculate the natural logarithm of a number") {
        
    }
    
    public double Calculate(double operand) {
        return Math.Log(operand);
    }
}