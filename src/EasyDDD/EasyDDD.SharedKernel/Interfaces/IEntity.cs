namespace EasyDDD.SharedKernel.Interfaces
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
