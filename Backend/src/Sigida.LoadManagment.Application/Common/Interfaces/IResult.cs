namespace Sigida.LoadManagment.Application;

public interface IResult<T>
{
    public T Payload { get; }
    public string Reason { get; }
    public bool IsSuccess { get; }
}
