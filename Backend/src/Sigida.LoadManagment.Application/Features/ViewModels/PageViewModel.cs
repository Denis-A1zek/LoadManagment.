using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.ViewModels;

public sealed record PageViewModel<T>
    (IEnumerable<T> Values, int TotalValues, int TotalPage);
