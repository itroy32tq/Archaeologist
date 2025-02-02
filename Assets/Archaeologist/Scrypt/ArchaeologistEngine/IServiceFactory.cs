namespace ArchaeologistEngine
{
    public interface IServiceFactory
    {
        T Create<T>() where T : class;
    }
}
