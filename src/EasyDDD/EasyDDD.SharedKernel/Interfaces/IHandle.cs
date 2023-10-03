namespace EasyDDD.SharedKernel.Interfaces
{
    public interface IHandle<T> where T : class
    {
        Task HandleAsync(T args);
    }
}
