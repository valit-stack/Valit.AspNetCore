namespace Valit.AspNetCore.Resolvers
{
    internal interface IValitDependencyResolver
    {
         TImplementation Resolve<TImplementation>() where TImplementation : class;
    }
}
