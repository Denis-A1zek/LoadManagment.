using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Domain.Entities;

public class SubjectSchedule : Identity
{
    public int Course { get; set; }
    public int Semester { get; set; }
    public int LectureHours { get; set; }
    public int LabHours { get; set; }
    public int PracticeHours { get; set; }
    public int SelfHours { get; set; }
}
