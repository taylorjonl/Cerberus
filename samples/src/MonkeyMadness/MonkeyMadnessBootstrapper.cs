using Cerberus.DependencyInjection;

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
        }
    }
}
