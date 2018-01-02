namespace Valit.AspNetCore.Executors
{
    internal interface IValitatorExecutor
    {
        IValitResult ExecuteValidation(object model);
    }
}
