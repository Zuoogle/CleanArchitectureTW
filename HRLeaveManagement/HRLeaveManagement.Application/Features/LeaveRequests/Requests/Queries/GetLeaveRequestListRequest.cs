using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest:IRequest<List<LeaveRequestListDto>>
    {
    }
}
