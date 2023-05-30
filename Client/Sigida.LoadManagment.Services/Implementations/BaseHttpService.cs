using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Services.Implementations
{
    public class BaseHttpService
    {
        protected readonly HttpClient HttpClient;

        public BaseHttpService(HttpClient httpClient)
            => HttpClient = httpClient;
    }
}
