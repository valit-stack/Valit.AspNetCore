using System;

namespace Valit.AspNetCore.Contexts
{
    internal class ValitAspNetContext : IValitAspNetContext
    {
        public IValitStrategy Strategy { get; private set; }

        void IValitAspNetContext.WithStrategy(IValitStrategy strategy)
            => Strategy = strategy;

        void IValitAspNetContext.WithStrategy(Func<DefaultValitStrategies, IValitStrategy> picker)
            => Strategy = picker(new DefaultValitStrategies());
    }
}
