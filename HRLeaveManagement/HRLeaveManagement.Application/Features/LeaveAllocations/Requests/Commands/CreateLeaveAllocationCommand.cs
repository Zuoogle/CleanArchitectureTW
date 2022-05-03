using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand:IRequest<int>
    {
        public CreateLeaveAllocationDto? LeaveAllocationDto { get; set; }
    }
}
