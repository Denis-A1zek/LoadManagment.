using Sigida.LoadManagment.Services.Interfaces;
using Sigida.LoadManagment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Sigida.LoadManagment.Shared;
using Sigida.LoadManagment.Shared.DataObject;

namespace Sigida.LoadManagment.Services.Implementations;

internal class EmployeeService : BaseHttpService, IEmployeeService
{
    public EmployeeService(HttpClient httpClient) : base(httpClient) { }

    public async Task<Response<IEnumerable<EmployeeViewModel>>> GetAll()
    {
        var response = await HttpClient.GetAsync("api/employees");

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var result = await response.Content.ReadFromJsonAsync<Response<IEnumerable<EmployeeViewModel>>>();
        return result ?? new Response<IEnumerable<EmployeeViewModel>>() { Payload = Enumerable.Empty<EmployeeViewModel>() };
    }

    public async Task<string> Create(EmployeeCreateDto employee)
    {
        var response = await HttpClient.PostAsJsonAsync<EmployeeCreateDto>("api/employee", employee);

        if(!response.IsSuccessStatusCode)
            return "Не удалось добавить нового пользователя";

        var result = await response.Content.ReadFromJsonAsync<Response<Guid>>();
        return $"Новый пользователь с идентефикатором {result.Payload} успешно добавлен";
    }

    public async Task<Result<Guid>> DeleteAsync(Guid id)
    {
        var response = await HttpClient.DeleteAsync($"api/employee/{id}");

        if (!response.IsSuccessStatusCode)
            return new Result<Guid>(Guid.Empty, "Не удалось удалить пользователя");

        var result = await response.Content.ReadFromJsonAsync<Response<Guid>>();
        return new Result<Guid>(result.Payload, "Пользователь успешно удален");
    }
}
