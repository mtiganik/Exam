using Microsoft.EntityFrameworkCore;
using MigrationProject;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IUserGetter _userGetter;

        public StudentService(AppDbContext context, IUserGetter userGetter)
        {
            _context = context;
            _userGetter = userGetter;
        }
        public async Task<IEnumerable<StudentHwDTO>> GetStudentHws()
        {
            var currUser = await _userGetter.GetCurrentUserAsync();
            var homeworks = await _context.UsersInSubject
                .Where(u => u.UserId == currUser.Id)
                .SelectMany(u => u.HwsForStudent)
                .Select(hfs => new StudentHwDTO
                {
                    Title = hfs.Homework.Title,
                    Description = hfs.Homework.Description,
                    DateDone = hfs.DateDone,
                    Deadline = hfs.Homework.Deadline,
                    SubjectName = hfs.Homework.Subject.Title,
                    GradeAsString = hfs.Grade.GradeName,
                    SubjectId = hfs.Homework.Subject.Id,
                    StudentName = currUser.FirstName + currUser.LastName
                }).ToListAsync();
            return homeworks;

        }

        public async Task<IEnumerable<FrontPageSubjectDTO>> GetStudentSubjects()
        {

            var currUser = await _userGetter.GetCurrentUserAsync();
            var subs = await _context.UsersInSubject
                .Where(u => u.UserId == currUser.Id)
                .Select(u => new StudentSubjectsDTO
                {
                    SemesterName = u.Subject.Semester.SemesterName,
                    Description = u.Subject.Description,
                    Title = u.Subject.Title,
                    StudentsCnt = u.Subject.UsersInSubject.Count(),
                }).ToListAsync();
            return subs;

        }

        public async Task<IEnumerable<string>> GetUsersForSubject(Guid subjectId)
        {
            var happy = new string("fdsfds");
            var res = await _context.UsersInSubject.Where(u => u.SubjectId == subjectId)
                .Select(u => new string(
                    u.User.FirstName + u.User.LastName))
                .ToListAsync();

            return res;
        }
    }
}
