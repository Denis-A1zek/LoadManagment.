using Sigida.LoadManagment.Services.Interfaces;
using Sigida.LoadManagment.Shared;
using Sigida.LoadManagment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Services.Implementations
{
    internal sealed class PositionsService : BaseHttpService, IPositionsService
    {
        public PositionsService(HttpClient httpClient) : base(httpClient) { }

        public async Task<Response<IEnumerable<PositionViewModel>>> GetPositions()
        {
            var response = await HttpClient.GetAsync("api/positions");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var result = await response.Content.ReadFromJsonAsync<Response<IEnumerable<PositionViewModel>>>();
            return result;
        }
    }
}
