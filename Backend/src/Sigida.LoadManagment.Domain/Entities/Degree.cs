using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Domain.Entities
{
    public class Degree : Identity
    {
        public string Title { get; set; } = null!;
    }
}
