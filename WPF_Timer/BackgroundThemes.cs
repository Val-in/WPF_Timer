using System.Windows.Media;

namespace WPF_Timer;

public class BackgroundThemes
{
    private List<Brush> _themes = new()
    {
        Brushes.LightBlue, Brushes.LightGreen, Brushes.LightCoral, Brushes.LightGoldenrodYellow
    };
    private int _index = 0;
    
    public Brush GetNextTheme()
    {
        var brush = _themes[_index];
        _index = (_index + 1) % _themes.Count;
        return brush;
    }
}