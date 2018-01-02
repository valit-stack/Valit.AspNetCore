using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Valit.AspNetCore.Executors;
using Valit.AspNetCore.ModelValidators;

namespace Valit.AspNetCore.ModelValidatorProviders
{
	internal class ModelValitatorProvider : IModelValidatorProvider
	{
        private readonly IValitatorExecutor _valitatorEecutor;

        public ModelValitatorProvider(IValitatorExecutor valitatorExecutor)
        {
            _valitatorEecutor = valitatorExecutor;
        }
        
		public void CreateValidators(ModelValidatorProviderContext context)
		{
			if(context.ModelMetadata.MetadataKind != ModelMetadataKind.Type)
            {
                return;
            }

            var validatorItem = new ValidatorItem
            {
                Validator = new ModelValitator(_valitatorEecutor),
                IsReusable = true
            };

            context.Results.Add(validatorItem);
		}
	}
}