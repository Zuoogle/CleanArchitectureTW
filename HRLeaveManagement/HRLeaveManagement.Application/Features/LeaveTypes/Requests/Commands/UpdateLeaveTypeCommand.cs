using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand:IRequest<Unit>
    {
        public UpdateLeaveTypeDto? LeaveTypeDto { get; set; }
    }
}
