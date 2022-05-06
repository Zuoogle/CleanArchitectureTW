using HRLeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HRLeaveManagementDbContext _dbcontext;

        public LeaveRequestRepository(HRLeaveManagementDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbcontext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _dbcontext.LeaveRequests
                .Include(q=>q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbcontext.LeaveRequests
                .Include(q=>q.LeaveType)
                .FirstOrDefaultAsync(q=>q.Id == id);
            #pragma warning disable CS8603 // Possible null reference return.
            return leaveRequest;
            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
