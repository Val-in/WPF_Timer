using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace WPF_Timer;

public partial class BasicTimer : Window
{
    private Stopwatch _stopwatch;
    private DispatcherTimer _timer;
    private bool _isRunning;
    
    public BasicTimer()
    {
        InitializeComponent();

        _stopwatch = new Stopwatch();
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(50) // обновляем каждые 50мс
        };
        _timer.Tick += Timer_Tick;
    }

    private void StartStopButton_Click(object sender, RoutedEventArgs e)
    {
        if (_isRunning)
        {
            _stopwatch.Stop();
            _timer.Stop();
            StartStopButton.Content = "Старт";
            
            StopRecords.Items.Insert(0, _stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff"));
        }
        else
        {
            _stopwatch.Start();
            _timer.Start();
            StartStopButton.Content = "Стоп";
        }

        _isRunning = !_isRunning;
    }

    private void ResetButton_Click(object sender, RoutedEventArgs e)
    {
        _stopwatch.Reset();
        TimeDisplay.Text = "00:00:00.000";

        if (_isRunning)
        {
            _stopwatch.Start();
        }
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        TimeDisplay.Text = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        StartPage startPage = new StartPage();
        startPage.Show();
        this.Close();
    }

    private void ContinueButton_Click(object sender, RoutedEventArgs e)
    {
        if (!_isRunning)
        {
            _stopwatch.Start();
            _timer.Start();
            StartStopButton.Content = "Стоп";
            _isRunning = true;
        }
    }
}   