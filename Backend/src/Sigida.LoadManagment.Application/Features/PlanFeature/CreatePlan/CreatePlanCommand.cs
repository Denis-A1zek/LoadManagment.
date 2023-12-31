﻿using AutoMapper;
using MediatR;
using Sigida.LoadManagment.Application;
using Sigida.LoadManagment.Application.Mappings;
using Sigida.LoadManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features;

public sealed record CreatePlanCommand : IRequest<IResult<Guid>>
{
    public CreatePlanCommand(string title, string description,
        DateTime? startDate = null,
        DateTime? endDate = null)
    {
        Title = title;
        Description = description;
        StartDate = startDate ?? new DateTime(DateTime.Now.Year, 09, 1);
        EndDate = endDate ?? StartDate.Value.AddMonths(10);
    }

    public string Title { get; set; } = null!;
    public string? Description { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}
