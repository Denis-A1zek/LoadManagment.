using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Mappings
{
    public interface IMapWith<TSource>
    {
        void Mapping(Profile profile);
    }
}
