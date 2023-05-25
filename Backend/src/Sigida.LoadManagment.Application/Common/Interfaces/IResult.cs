using Sigida.LoadManagment.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application;

public interface IResult<T>
{
    public T Payload { get; }
    public string Reason { get; }
    public bool IsSuccess { get; }
}
