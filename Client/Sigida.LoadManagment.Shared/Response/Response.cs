using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Shared;

public sealed record Response<T>
{
    public T Payload { get; init; }
    public string Reason { get; init; }
    public bool IsSuccess { get; init; }
}
