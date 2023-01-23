using System.Threading.Tasks;
using Cerberus.Presentation.Alerting;
using Microsoft.Maui.Controls;

namespace MonkeyMadness.Maui.Presentation.Alerting;

public class AlertService : IAlertService
{
    public Task ShowAlertAsync(string title, string message)
    {
        return Shell.Current.DisplayAlert(title, message, "OK");
    }
}
