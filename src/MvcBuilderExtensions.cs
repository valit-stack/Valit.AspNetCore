using System;
using Microsoft.Extensions.DependencyInjection;
using Valit.AspNetCore.Contexts;
using Valit.AspNetCore.Executors;
using Valit.AspNetCore.Factories;
using Valit.AspNetCore.ModelValidatorProviders;
using Valit.AspNetCore.Resolvers;

namespace Valit.AspNetCore
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddValit(this IMvcBuilder builder, Func<IValitAspNetContext, IValitAspNetContext> contextFunc)
        {
            var context = contextFunc(new ValitAspNetContext());

            builder.Services.Scan(s => s.FromApplicationDependencies()
                .AddClasses(c => c.AssignableTo(typeof(IValitator<>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            builder.Services.AddSingleton(context);
            builder.Services.AddTransient<IValitDependencyResolver, ValitDependencyResolver>();
            builder.Services.AddTransient<IValitatorFactory, ValitatorFactory>();
            builder.Services.AddTransient<IValitatorExecutor, ValitatorExecutor>();
            builder.Services.AddTransient<ModelValitatorProvider, ModelValitatorProvider>();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var valitatorProvider = serviceProvider.GetService<ModelValitatorProvider>();

            builder.AddMvcOptions(options => options.ModelValidatorProviders.Insert(0, valitatorProvider));
            return builder;
        }
    }
}
