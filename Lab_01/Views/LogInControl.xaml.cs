using System.Windows.Controls;

namespace KMA.CSharp2020.Lab01
{
    /// <summary>
    /// Interaction logic for LogInControl.xaml
    /// </summary>
    public partial class LogInControl : UserControl
    {
        public LogInControl()
        {
            InitializeComponent();
            DataContext = new LogInViewModel();
        }
    }
}
