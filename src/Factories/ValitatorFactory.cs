using Valit.AspNetCore.Resolvers;

namespace Valit.AspNetCore.Factories
{
    internal class ValitatorFactory : IValitatorFactory
    {
        private readonly IValitDependencyResolver _valitDependencyResolver;

        public ValitatorFactory(IValitDependencyResolver valitDependencyResolver)
        {
            _valitDependencyResolver = valitDependencyResolver;
        }

        public IValitator<TObject> GetValitator<TObject>() where TObject : class
            => _valitDependencyResolver.Resolve<IValitator<TObject>>();
    }
}
