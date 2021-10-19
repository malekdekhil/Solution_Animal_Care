using Animal_Care_WebAPI.Resources.EventResources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Care_WebAPI.Validations
{
    public class EventValidator: AbstractValidator<SaveEventResouce>
    {
        public EventValidator()
        {
            RuleFor(a => a.DateEvent);
            RuleFor(a => a.Status);
           }
    }
}
