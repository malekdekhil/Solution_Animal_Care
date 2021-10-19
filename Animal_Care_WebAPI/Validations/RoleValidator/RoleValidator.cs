using Animal_Care_WebAPI.Resources.RoleResources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Care_WebAPI.Validations
{
    public class RoleValidator: AbstractValidator<RoleResource>
    {
        public RoleValidator()
        {
            RuleFor(a => a.RoleName).NotEmpty();
            RuleFor(a => a.RoleId_FK).NotEmpty();
        }
    }
}
