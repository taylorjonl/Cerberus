using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Cerberus.Presentation;
using Cerberus.Presentation.Alerting;
using Cerberus.Presentation.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonkeyMadness.Data;
using MonkeyMadness.Services;

namespace MonkeyMadness.Presentation.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IAlertService alertService;
    private readonly INavigationService navigationService;
    private readonly IMonkeyService monkeyService;

    public MainViewModel(IAlertService alertService, INavigationService navigationService, IMonkeyService monkeyService)
    {
        this.alertService = alertService;
        this.navigationService = navigationService;
        this.monkeyService = monkeyService;

        Title = "Monkey Finder";
    }

    public ObservableCollection<Monkey> Monkeys { get; } = new();

    [ObservableProperty]
    private bool isRefreshing;

    [RelayCommand]
    private async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeysAsync();

            if (Monkeys.Count != 0)
            {
                Monkeys.Clear();
            }

            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await alertService.ShowAlertAsync("Error!", ex.Message);
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    private async Task GoToDetailsAsync(Monkey monkey)
    {
        await navigationService.GoToAsync<MonkeyDetailsViewModel>(viewModel =>
        {
            viewModel.Monkey = monkey;
        });
    }

    [RelayCommand]
    private async Task GetClosestMonkeyAsync()
    {
        if (IsBusy || Monkeys.Count == 0)
        {
            return;
        }

        await Task.CompletedTask;
    }
}
