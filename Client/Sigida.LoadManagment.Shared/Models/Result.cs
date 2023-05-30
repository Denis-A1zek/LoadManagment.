namespace Sigida.LoadManagment.Shared.Models;

public sealed record Result<T>
    (T Value, string Message);
