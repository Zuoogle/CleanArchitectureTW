using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand:IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto? LeaveRequestDto { get; set; }
        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }
    }
}
