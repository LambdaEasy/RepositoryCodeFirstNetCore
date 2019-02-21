namespace Lambda.Domain.Base
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }
}