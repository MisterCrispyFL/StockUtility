namespace StockUtilities
{
    using System.Windows;
    using System.Windows.Input;
    using StockStuff;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow
    {
        public MainWindow()
        {
            EventManager.RegisterClassHandler(typeof(System.Windows.Controls.TextBox), 
                GotKeyboardFocusEvent, 
                new KeyboardFocusChangedEventHandler(OnGotKeyboardFocus));

            InitializeComponent();
        }

        
    }
}
