using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MemberValidator:AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.MemberNo).NotEmpty();
        }
    }
}
