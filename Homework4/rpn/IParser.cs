namespace Homework4.rpn; 

public interface IParser {
    
    public IList<string> SupportedOperators { get; set; }

    public IList<string> Tokenize(string expression);

    public IList<Token> Lex(IList<string> expression);
    

}