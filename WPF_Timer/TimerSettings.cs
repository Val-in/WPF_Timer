using System.Xml.Linq;

namespace WPF_Timer;

public class TimerSettings
{
    public int TimerInterval { get; set; }
    public int MaxValue { get; set; }

    public static TimerSettings LoadSettings(string fieldPath)
    {
        var doc = XDocument.Load(fieldPath);
        return new TimerSettings
        {
            TimerInterval = int.Parse(doc.Root.Element("TimerInterval").Value),
            MaxValue = int.Parse(doc.Root.Element("MaxValue").Value)
        };
    }


}