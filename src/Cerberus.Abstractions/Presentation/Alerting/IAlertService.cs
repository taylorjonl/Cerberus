using System.Threading.Tasks;

namespace Cerberus.Presentation.Alerting;

public interface IAlertService
{
    Task ShowAlertAsync(string title, string message);
}
