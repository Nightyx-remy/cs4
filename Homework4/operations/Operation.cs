namespace Homework4.operations; 

public class Operation : IOperation {
    public string Name { get; }
    public string Operator { get; }
    public string Description { get; }

    public Operation(string name, string @operator, string description) {
        Name = name;
        Operator = @operator;
        Description = description;
    }
}