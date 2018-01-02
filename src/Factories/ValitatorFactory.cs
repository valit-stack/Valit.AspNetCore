using Valit.AspNetCore.Resolvers;

namespace Valit.AspNetCore.Factories
{
    internal class ValitatorFactory : IValitatorFactory
    {
        private readonly IValitDependencyResolver _valitDependencyResovler;

        public ValitatorFactory(IValitDependencyResolver valitDependencyResovler)
        {
            _valitDependencyResovler = valitDependencyResovler;
        }

        public IValitator<TObject> GetValitator<TObject>() where TObject : class
            => _valitDependencyResovler.Resolve<IValitator<TObject>>();
    }
}
