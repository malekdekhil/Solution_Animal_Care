using Animal_Care_WebAPI.Resources.EventResources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Care_WebAPI.Validations
{
    public class EventUpdateValidator:AbstractValidator<EventResourceUpdate>
    {
        public EventUpdateValidator()
        {

            RuleFor(a => a.DateEvent).NotEmpty().When(a => a.DateEvent < DateTime.Now)
            .GreaterThan(DateTime.Now).WithMessage("Veuillez vérifier votre saisie");
            RuleFor(a => a.Status).NotEmpty();

        }
    }
}
