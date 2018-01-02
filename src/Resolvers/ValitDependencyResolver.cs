using System;

namespace Valit.AspNetCore.Resolvers
{
    internal class ValitDependencyResolver : IValitDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public ValitDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TImplementation Resolve<TImplementation>() where TImplementation : class
            => _serviceProvider.GetService(typeof(TImplementation)) as TImplementation;
    }
}
