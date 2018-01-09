using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Valit.AspNetCore.Executors;

namespace Valit.AspNetCore.ModelValidators
{
	internal class ModelValitator : IModelValidator
	{
		private readonly IValitatorExecutor _valitatorExecutor;
        private readonly IValitAspNetContext _valitAspNetContext;

        public ModelValitator(IValitatorExecutor valitatorExecutor, IValitAspNetContext valitAspNetContext)
		{
			_valitatorExecutor = valitatorExecutor;
            _valitAspNetContext = valitAspNetContext;
		}

		public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
		{
            var strategy = _valitAspNetContext.Strategy;
            var valitResult = _valitatorExecutor.ExecuteValidation(context.Model, strategy);
			return valitResult.ErrorMessages.Select(em => new ModelValidationResult(string.Empty, em));
		}
	}
}
