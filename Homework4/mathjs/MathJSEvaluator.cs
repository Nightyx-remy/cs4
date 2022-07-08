namespace Homework4.mathjs; 

public class MathJSEvaluator: IExpressionEvaluator {

    private HttpClient _httpClient = new HttpClient();
    
    public double Evaluate(string expression) {
        var response = _httpClient.GetAsync($"http://api.mathjs.org/v4/?expr={expression.Replace("+", "%2B")}").Result;
        var text = response.Content.ReadAsStringAsync().Result;

        if (!response.IsSuccessStatusCode) throw new HttpRequestException($"Failed to send request for {expression}!");
        return Convert.ToDouble(text);
    }

    public IList<string> Help => new List<string> { "All maths expressions supported" };
    public string Description => "Math JS Calculator";
}