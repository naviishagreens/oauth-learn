using Microsoft.AspNetCore.Mvc;
using StudentApi.BL;
using StudentApi.Model;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentBL studentService;
        public StudentController(IStudentBL bl)
        {
            this.studentService = bl;
        }

        public Student[] Get()
        {
            return this.studentService.GetStudents();
        }

    }
}
