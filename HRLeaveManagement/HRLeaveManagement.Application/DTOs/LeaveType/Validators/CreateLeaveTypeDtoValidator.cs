using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveRequestDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
