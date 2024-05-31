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
    public class FrontPageService : IFrontPageService
    {
        private readonly AppDbContext _context;

        public FrontPageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FrontPageSubjectDTO>> GetFrontPageSubjects()
        {
            List<FrontPageSubjectDTO> res = new List<FrontPageSubjectDTO>();
            var subs = await _context.Subjects.ToListAsync();

            foreach (var el in subs)
            {
                var teacher = await _context.UsersInSubject
                    .Where(s => s.SubjectId == el.Id)
                    .Where(u => u.UserRoleInSubject.RoleName == "Teacher")
                    .Select(u => u.User).FirstOrDefaultAsync();

                res.Add(new FrontPageSubjectDTO
                {
                    Title = el.Title,
                    Description = el.Description,
                    Teacher = teacher == null ? "" : teacher.FirstName + " " + teacher.LastName,
                    SemesterName = el.Semester.SemesterName,
                    StudentsCnt = el.UsersInSubject!.Count()
                }); 
            }
            return res;
        }
    }
}
