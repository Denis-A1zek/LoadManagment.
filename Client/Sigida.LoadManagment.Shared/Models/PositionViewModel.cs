using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Shared.Models
{
    public sealed record PositionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string LoadRange { get; set; }
    }
}
