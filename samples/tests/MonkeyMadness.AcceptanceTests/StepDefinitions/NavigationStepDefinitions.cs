using System;
using System.Threading.Tasks;
using Cerberus.DependencyInjection;
using Cerberus.Presentation;
using Cerberus.Presentation.Navigation;
using MonkeyMadness.AcceptanceTests.Support;
using MonkeyMadness.Constants;
using MonkeyMadness.Data;
using MonkeyMadness.Presentation.ViewModels;
using TechTalk.SpecFlow;
using Xunit;

namespace MonkeyMadness.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        private readonly TestBootstrapper bootstrapper = new TestBootstrapper();
        private readonly Monkey monkey = new Monkey
        {
            Name = "Baboon"
        };

        [Given(@"the application is started")]
        public async Task TheApplicationIsStarted()
        {
            await this.bootstrapper.Run();
        }

        [Given(@"the application is not started")]
        public void TheApplicationIsNotStarted()
        {
        }

        [Given(@"the active view is the '([^']*)' view")]
        [Then(@"the active view will be the '([^']*)' view")]
        public void TheActiveViewWillBeView(string viewName)
        {
            var activeViewType = this.bootstrapper.NavigationService.ActiveView?.GetType();
            Assert.NotNull(activeViewType);
            var viewModelType = viewName switch
            {
                ViewNames.Main => typeof(MainViewModel),
                ViewNames.MonkeyDetails => typeof(MonkeyDetailsViewModel),
                _ => null
            };
            Assert.NotNull(viewModelType);
            Assert.Equal(viewModelType, activeViewType);
        }

        [When(@"the user requests to go to the details for a monkey")]
        public async Task TheGoToDetailsCommandIsExecuted()
        {
            var mainViewModel = Assert.IsType<MainViewModel>(this.bootstrapper.NavigationService.ActiveView);
            await mainViewModel.GoToDetailsCommand.ExecuteAsync(this.monkey);
        }

        [Then(@"the active view will be null")]
        public void TheActiveViewWillBeNull()
        {
            var activeViewType = this.bootstrapper.NavigationService.ActiveView?.GetType();
            Assert.Null(activeViewType);
        }

        private class TestBootstrapper : TestsBootstrapper
        {
            protected override void OnBeforeRun()
            {
                this.NavigationService = this.DependencyResolver!.Resolve<NavigationService>();
            }
        }

        private class NavigationService : INavigationService
        {
            private readonly IDependencyResolver dependencyResolver;

            public NavigationService(IDependencyResolver dependencyResolver)
            {
                this.dependencyResolver = dependencyResolver;
            }

            public ViewModelBase? ActiveView { get; private set; }

            public Task GoToAsync<TViewModel>(Action<TViewModel>? configure = null)
                where TViewModel : ViewModelBase
            {
                var viewModel = this.dependencyResolver.Resolve<TViewModel>();
                configure?.Invoke(viewModel);
                this.ActiveView = viewModel;
                return Task.CompletedTask;
            }
        }
    }
}
