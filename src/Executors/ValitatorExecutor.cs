using System;
using Valit.AspNetCore.Extensions;
using Valit.AspNetCore.Resolvers;

namespace Valit.AspNetCore.Executors
{
    internal class ValitatorExecutor : IValitatorExecutor
    {
        private readonly IValitDependencyResolver _valitDependencyResovler;

        public ValitatorExecutor(IValitDependencyResolver valitDependencyResovler)
        {
            _valitDependencyResovler = valitDependencyResovler;
        }

        public IValitResult ExecuteValidation(object model)
        {
            var modelType = model.GetType();
            var resolverType = _valitDependencyResovler.GetType();

            var modelValitator = resolverType.InvokeGenericMethod(nameof(IValitDependencyResolver.Resolve), modelType, _valitDependencyResovler);
            var modelValitatorType = modelValitator.GetType();

            return (IValitResult) modelValitatorType.InvokeGenericMethod(nameof(IValitator<object>.Validate), modelType, modelValitator, model);
        }       
    }
}
