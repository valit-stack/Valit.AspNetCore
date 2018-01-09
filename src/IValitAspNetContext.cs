using System;

namespace Valit.AspNetCore
{
    public interface IValitAspNetContext
    {
        IValitStrategy Strategy { get; }
        void WithStrategy(IValitStrategy strategy);
        void WithStrategy(Func<DefaultValitStrategies, IValitStrategy> picker);
    }
}
