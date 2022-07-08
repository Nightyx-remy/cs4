namespace Homework4.rpn; 

public class Parser : IParser {
    
    public IList<string> SupportedOperators { get; set; }

    public Parser(IList<string> supportedOperators) {
        SupportedOperators = supportedOperators;
    }

    public Parser() {
        SupportedOperators = new List<string>();
    }
    
    public IList<string> Tokenize(string expression) {
        return new List<string>(expression.Split(" "));
    }

    public IList<Token> Lex(IList<string> expression) {
        var tokens = new List<Token>();
        foreach (var part in expression) {
            foreach (var supportedOperator in SupportedOperators) {
                if (part != supportedOperator) continue;
                tokens.Add(new Token(TokenType.Operator, part));
                goto EOL;
            }
            // Not an operator
            tokens.Add(new Token(TokenType.Number, part));
            
            EOL: ;
        }

        return tokens;
    }
}