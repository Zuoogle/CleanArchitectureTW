using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand:IRequest<int>
    {
        public LeaveRequestDto? LeaveRequestDto { get; set; }
    }
}
