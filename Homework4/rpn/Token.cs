namespace Homework4.rpn; 

public class Token {
    
    public TokenType TokenType { get; }
    public string Value { get; }
    public double NumericValue { get; }
    public bool IsOperator { get; }
    public bool IsNumber { get; }

    public Token(TokenType tokenType, string text) {
        TokenType = tokenType;
        Value = text;
        IsOperator = tokenType == TokenType.Operator;
        IsNumber = tokenType == TokenType.Number;
        if (IsNumber) {
            NumericValue = Convert.ToDouble(text);
        }
    }

}