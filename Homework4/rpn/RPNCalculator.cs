using System.Collections;
using Homework4.operations;

namespace Homework4.rpn; 

public class RPNCalculator : ICalculator, ICollection<IOperation> {

    private List<IOperation> _operations = new ();

    public IList<string> SupportedOperators {
        get => _operations.Select(x => x.Operator).ToList();
    }
    public IList<string> OperationsHelpText {
        get => _operations.Select(x => $"{x.Operator} => {x.Description}").ToList();
    }

    private static void BinOp(Stack<double> stack, Func<(double, double), double> func) {
        var lhs = stack.Pop();
        var rhs = stack.Pop();
        stack.Push(func((lhs, rhs)));
    }

    private static void UnaryOp(Stack<double> stack, Func<double, double> func) {
        var val = stack.Pop();
        stack.Push(func(val));
    }
    
    public double Calculate(IList<Token> expression) {
        var stack = new Stack<double>();

        foreach (var token in expression) {
            if (token.IsNumber) {
                stack.Push(token.NumericValue);
            } else {
                var op = _operations.Find(op => op.Operator.Equals(token.Value));
                if (op != null) {
                    switch (op) {
                        case INullaryOperation constant:
                            stack.Push(constant.Value);
                            break;
                        case IUnaryOperation unary:
                            UnaryOp(stack, unary.Calculate);
                            break;
                        case IBinaryOperation binary:
                            BinOp(stack, (tuple) => binary.Calculate(tuple.Item1, tuple.Item2));
                            break;
                    }
                } else {
                    throw new InvalidOperationException($"Unknown expression {token.Value}!");
                }
            }
        }

        var result = stack.Pop();
        if (stack.Count != 0) throw new FormatException("Invalid expression!");
        return result;
    }

    public IEnumerator<IOperation> GetEnumerator() {
        return _operations.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void Add(IOperation item) {
        _operations.Add(item);
    }

    public void Clear() {
        _operations.Clear();
    }

    public bool Contains(IOperation item) {
        return _operations.Contains(item);
    }

    public void CopyTo(IOperation[] array, int arrayIndex) {
        _operations.CopyTo(array, arrayIndex);
    }

    public bool Remove(IOperation item) {
        return _operations.Remove(item);
    }

    public int Count {
        get => _operations.Count;
    }
    
    public bool IsReadOnly {
        get => false;
    }
}