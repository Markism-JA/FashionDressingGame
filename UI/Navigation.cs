namespace FashionDressingGame.UI
{
    public class Navigation
    {
        private Stack<Func<int>> _historyStack; // Stack to store history of windows/screens
        private Func<int> _currentWindow;
        
        // Navigate to a new window, push current window onto stack

        public Navigation()
        {
            _historyStack = new Stack<Func<int>>();
        }
        public void Navigate(Func<int> newWindow)
        {
            _historyStack.Push(_currentWindow); // Save current window to history
            _currentWindow = newWindow; // Move to new window
        }

        public void GoBack()
        {
            if (_historyStack.Count > 0)
            {
                _currentWindow = _historyStack.Pop(); // Go back to previous window
            }
            else
            {
                Console.WriteLine("No more windows in history to go back to.");
            }
        }

        public int ShowCurrentWindow()
        {
            return _currentWindow.Invoke(); // Call the current window's function
        }

    }
}