using AutoMapper;
using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Leave Request Mappings start

            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>()
                .ForMember(des=>des.DateRequested, opt=>opt.MapFrom(src=>src.DateCreated))
                .ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();

            #endregion Leave Request Mappings end

            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();  
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();


        }
    }
}
