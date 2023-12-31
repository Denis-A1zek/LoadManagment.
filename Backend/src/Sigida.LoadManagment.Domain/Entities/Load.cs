﻿using Sigida.LoadManagment.Domain.Enum;

namespace Sigida.LoadManagment.Domain.Entities;

public class Load : Identity
{
    public Guid SpecialtyId { get; set; }
    public Specialty? Specialty { get; set; }
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public List<SubjectSchedule>? SubjectSchedules { get; set; }
    public Guid PlanId { get; set; }
    public Plan? Plan { get; set; }
    public Status Status { get; set; }
    public bool IsCouting { get; set; }
}
