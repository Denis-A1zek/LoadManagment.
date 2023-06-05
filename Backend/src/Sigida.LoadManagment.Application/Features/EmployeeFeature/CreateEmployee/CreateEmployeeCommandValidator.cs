using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigida.LoadManagment.Application.Features.EmployeeFeature.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Matches("^[А-ЯЁ][А-ЯЁа-яё]*$").MinimumLength(2).MaximumLength(30);
            RuleFor(e => e.Surname).NotEmpty().Matches("^[А-ЯЁ][А-ЯЁа-яё]*$").MinimumLength(2).MaximumLength(60);
            RuleFor(e => e.Lastname).NotEmpty().Matches("^[А-ЯЁ][А-ЯЁа-яё]*$").MinimumLength(3).MaximumLength(60);
            RuleFor(e => e.PositionId).NotEmpty();
        }

    }
}
