namespace Homework4; 

public interface IMenu {
    
    public IList<string> Help { get; set; }

    public void ShowMenu();
    public void ShowHelp();

}