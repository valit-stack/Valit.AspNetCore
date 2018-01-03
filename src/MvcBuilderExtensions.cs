using Microsoft.Extensions.DependencyInjection;
using Valit.AspNetCore.Executors;
using Valit.AspNetCore.ModelValidatorProviders;
using Valit.AspNetCore.Resolvers;

namespace Valit.AspNetCore
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddValit<T>(this IMvcBuilder builder)
        {
            builder.Services.Scan(s => s.FromAssemblyOf<T>().AddClasses(c => c.AssignableTo(typeof(IValitator<>))).AsImplementedInterfaces());
            builder.Services.AddTransient<IValitDependencyResolver, ValitDependencyResolver>();
            builder.Services.AddTransient<IValitatorExecutor, ValitatorExecutor>();
            builder.Services.AddTransient<ModelValitatorProvider, ModelValitatorProvider>();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var valitatorProvider = serviceProvider.GetService<ModelValitatorProvider>();

            builder.AddMvcOptions(options => options.ModelValidatorProviders.Insert(0, valitatorProvider));
            return builder;
        }
    }
}
