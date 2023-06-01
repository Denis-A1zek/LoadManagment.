using AutoMapper;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.ViewModels;

public sealed record SubjectViewModel : IMapWith<Subject>
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Subject, SubjectViewModel>()
            .ReverseMap();

    }
}

