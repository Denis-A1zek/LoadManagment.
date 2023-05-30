using Sigida.LoadManagment.Shared;
using Sigida.LoadManagment.Shared.DataObject;
using Sigida.LoadManagment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Services.Interfaces;

public interface IEmployeeService
{
    Task<Response<IEnumerable<EmployeeViewModel>>> GetAll();
    Task<string> Create(EmployeeCreateDto employee);
    Task<Result<Guid>> DeleteAsync(Guid id); 
}
