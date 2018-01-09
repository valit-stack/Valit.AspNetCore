using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Valit.AspNetCore.Executors;
using Valit.AspNetCore.ModelValidators;

namespace Valit.AspNetCore.ModelValidatorProviders
{
	internal class ModelValitatorProvider : IModelValidatorProvider
	{
        private readonly IValitatorExecutor _valitatorExecutor;
        private readonly IValitAspNetContext _valitAspNetContext;

        public ModelValitatorProvider(IValitatorExecutor valitatorExecutor, IValitAspNetContext valitAspNetContext)
        {
            _valitatorExecutor = valitatorExecutor;
            _valitAspNetContext = valitAspNetContext;
        }
        
		public void CreateValidators(ModelValidatorProviderContext context)
		{
			if(context.ModelMetadata.MetadataKind != ModelMetadataKind.Type)
            {
                return;
            }

            var validatorItem = new ValidatorItem
            {
                Validator = new ModelValitator(_valitatorExecutor, _valitAspNetContext),
                IsReusable = true
            };

            context.Results.Add(validatorItem);
		}
	}
}
