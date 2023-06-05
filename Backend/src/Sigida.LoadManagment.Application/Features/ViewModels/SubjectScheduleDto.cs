using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.ViewModels;

public sealed record SubjectScheduleDto
{
    public int Course { get; set; }
    public int Semester { get; set; }
    public int LectureHours { get; set; }
    public int LabHours { get; set; }
    public int PracticeHours { get; set; }
    public int SelfHours { get; set; }
}
