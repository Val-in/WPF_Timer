using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;

namespace WPF_Timer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private TimerSettings _settings;
    private DispatcherTimer _timer;
    private ChartValues<double> _values;
    private int _currentValue;
    private BackgroundThemes _backgroundThemes;
    
    public ChartValues<double> Values { get; set; }
    
    public MainWindow()
    {
        try
        {
            InitializeComponent();

            _settings = TimerSettings.LoadSettings("TimerSettings.xml");
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(_settings.TimerInterval);
            _timer.Tick += TimerTick;
            _timer.Start();

            _values = new ChartValues<double> { 0.00 };
            Values = _values;
            Chart.DataContext = this;
           _currentValue = 1;
           
           _backgroundThemes = new BackgroundThemes();
           
           var animation = (Storyboard)this.Resources["ValueChangeAnimation"];
           animation.Begin(this.BackButton);
        }
        catch(Exception ex)
        {
            MessageBox.Show("Ошибка при инициализации:" + ex.Message);
        }
    }
    
    private void TimerTick(object sender, EventArgs e)
    {
        _currentValue += (_currentValue + 1) % _settings.MaxValue; 
        double yValue = Math.Round((double)_currentValue, 1);
        _values.Add(Math.Round(yValue, 2));
        
        if (_values.Count > 100)
        {
            _values.RemoveAt(0);       
        }
        
        this.Background = _backgroundThemes.GetNextTheme();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var animation = (Storyboard)this.Resources["ValueChangeAnimation"];
        animation.Stop(this.BackButton);
        
        StartPage startPage = new StartPage();
        startPage.Show();   
        this.Close();
    }
}