using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Valit.AspNetCore.Executors;

namespace Valit.AspNetCore.ModelValidators
{
	internal class ModelValitator : IModelValidator
	{
		private readonly IValitatorExecutor _valitatorExecutor;

		public ModelValitator(IValitatorExecutor valitatorExecutor)
		{
			_valitatorExecutor = valitatorExecutor;
		}

		public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
		{
            var valitResult = _valitatorExecutor.ExecuteValidation(context.Model);
			return valitResult.ErrorMessages.Select(em => new ModelValidationResult(string.Empty, em));
		}
	}
}
