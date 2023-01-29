using Cerberus.DependencyInjection;
using Cerberus.Presentation.Navigation;
using MonkeyMadness.Presentation.ViewModels;

namespace MonkeyMadness
{
    public class MonkeyMadnessBootstrapper
    {
        public MonkeyMadnessBootstrapper(IDependencyResolver dependencyResolver)
        {
            DependencyResolver = dependencyResolver;
        }

        public IDependencyResolver DependencyResolver { get; }

        public virtual void Run()
        {
            var navigationService = this.DependencyResolver.Resolve<INavigationService>();
            navigationService.GoToAsync<MainViewModel>();
        }
    }
}
