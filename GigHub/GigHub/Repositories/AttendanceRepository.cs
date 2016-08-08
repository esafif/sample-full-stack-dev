﻿using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GigHub.Repositories
{
    public class AttendanceRepository
    {
        private ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetFutureAttendances(string userId)
        {
            return await _context.Attendances
                            .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                            .ToListAsync();
        }

        public async Task<Attendance> GetAttendance(int gigId, string attendeeId)
        {
            return await _context.Attendances
                    .FirstOrDefaultAsync(a => a.GigId == gigId && a.AttendeeId == attendeeId);
        }
    }
}
