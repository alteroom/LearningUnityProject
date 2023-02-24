namespace Modules.GameSystem
{
    public interface IServicesContext
    {
        void RegisterService(object service);
        void UnregisterService(object service);
        T GetService<T>();
        bool TryGetService<T>(out T service);
        T[] GetServices<T>();
    }
}