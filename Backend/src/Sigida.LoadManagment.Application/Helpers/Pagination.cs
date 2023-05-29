using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Helpers
{
    internal static class Pagination
    {
        public static int CalculateNumberOfPages(int numberOfValues, int pageSize)
            => (int)Math.Ceiling((decimal)numberOfValues / pageSize);

        public static int CalculateNumberOfSkips(int numberOfPage, int pageSize)
            => (numberOfPage - 1) * pageSize;
    }
}
