namespace FashionDressingGame.UI;

public class Navigation
{
    private Stack<Func<int>> _historyStack;
    private Func<int> _curentWindow;
    private Func<int> _mainMenu;

    public Navigation()
    {
        _historyStack = new Stack<Func<int>>();
    }
    

}