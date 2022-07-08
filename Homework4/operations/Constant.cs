namespace Homework4.operations; 

public class Constant : Operation, INullaryOperation {

    public Constant(string name, string @operator, string description, double value) : base(name, @operator,
        description) {
        Value = value;
    }
    
    public double Value { get; }
}