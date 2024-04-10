using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace H6Oef6._6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private int _totalSeconds=0;
        private Rectangle minuteRectangle;
        private Rectangle secondRectangle;
        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromMilliseconds(200);
            _timer.Tick += Timer_Tick;

            minuteRectangle = CreateRectangle(Colors.Blue);
            secondRectangle = CreateRectangle(Colors.Red);

            timeCanvas.Children.Add(minuteRectangle);
            timeCanvas.Children.Add(secondRectangle);
        }
         
        private void Timer_Tick(object sender, EventArgs e)
        {
            minuteRectangle.Width = (_totalSeconds / 60) * 10;
            secondRectangle.Width = (_totalSeconds % 60) * 10;

            _totalSeconds++;
            int minutes = _totalSeconds / 60;
            int seconds = _totalSeconds % 60;

            timeLabel.Content = $"Totale tijd verstreken: {minutes:00}min:{seconds:00}sec";
        }

        private Rectangle CreateRectangle(Color color)
        {
            Rectangle rectangle = new Rectangle()
            {
                Height = 60,
                Fill = new SolidColorBrush(color),
                Margin = new Thickness(60,0,0,0)
            };
            return rectangle;
        }



        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void clearButton_Click_1(object sender, RoutedEventArgs e)
        {
            timeCanvas.Children.Clear();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }
    }
}