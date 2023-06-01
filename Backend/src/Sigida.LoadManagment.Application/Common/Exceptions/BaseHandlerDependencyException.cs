using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Common.Exceptions;

public sealed class BaseHandlerDependencyException : Exception
{
    public BaseHandlerDependencyException(string? message, Type type) : base(message)
    {
        Message = message;
        Type = type;
    }
    public string Message { get; }
    public Type Type { get; }

}
