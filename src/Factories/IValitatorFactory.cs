namespace Valit.AspNetCore.Factories
{
    internal interface IValitatorFactory
    {
        IValitator<TObject> GetValitator<TObject>() where TObject : class;
    }
}
