using Valit.AspNetCore.Extensions;
using Valit.AspNetCore.Factories;

namespace Valit.AspNetCore.Executors
{
    internal class ValitatorExecutor : IValitatorExecutor
    {
        private readonly IValitatorFactory _valitatorFactory;

        public ValitatorExecutor(IValitatorFactory valitatorFactory)
        {
            _valitatorFactory = valitatorFactory;
        }

        public IValitResult ExecuteValidation(object model)
        {
            var modelType = model.GetType();
            var valitatorFactoryType = _valitatorFactory.GetType();

            var modelValitator = valitatorFactoryType.InvokeGenericMethod(nameof(IValitatorFactory.GetValitator), modelType, _valitatorFactory);
            var modelValitatorType = modelValitator.GetType();

            return (IValitResult) modelValitatorType.InvokeMethod(nameof(IValitator<object>.Validate), modelValitator, model, null);
        }       
    }
}
