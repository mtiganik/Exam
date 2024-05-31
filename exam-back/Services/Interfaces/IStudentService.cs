using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentHwDTO>> GetStudentHws();

        Task<IEnumerable<FrontPageSubjectDTO>> GetStudentSubjects();
        Task<IEnumerable<string>> GetUsersForSubject(Guid subjectId);
    }
}
