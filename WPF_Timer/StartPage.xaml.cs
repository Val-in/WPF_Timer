using System.Windows;

namespace WPF_Timer;

public partial class StartPage : Window
{
    public StartPage()
    {
        InitializeComponent();
    }

    private void BasicTimerButton_Click(object sender, RoutedEventArgs e)
    {
        BasicTimer basicTimer = new BasicTimer();
        basicTimer.Show();
        this.Close();
    }
    private void ChartTimerButton_Click(object sender, RoutedEventArgs e)
    {
        MainWindow chartTimer = new MainWindow();
        chartTimer.Show();
        this.Close();
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}