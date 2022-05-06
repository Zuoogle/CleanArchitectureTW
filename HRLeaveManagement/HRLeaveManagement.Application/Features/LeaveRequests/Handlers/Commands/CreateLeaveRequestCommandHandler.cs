using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Application.Contracts.Infrastructure;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using System.Linq;
using HRLeaveManagement.Application.Models;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSendr;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, 
            ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSendr, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSendr = emailSendr;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            #pragma warning disable CS8604 // Possible null reference argument.
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            #pragma warning restore CS8604 // Possible null reference argument.

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Create Failed!";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            response.Success = true;
            response.Message = "Created Successfully";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "leavemanagementHr@gmail.com",
                Body = $"Your leave request for " +
                $"{request.LeaveRequestDto.StartDate:D} " +
                $"to {request.LeaveRequestDto.EndDate:D} has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };
            try
            {
                await _emailSendr.SendEmail(email);
            }
            catch (Exception)
            {

                ////Log or handle error , but don't throw...;
            }
            return response;
        }

        //Task<BaseCommandResponse> IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>.Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
