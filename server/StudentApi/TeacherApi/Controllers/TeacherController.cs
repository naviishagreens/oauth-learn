using Microsoft.AspNetCore.Mvc;
using TeacherApi.BL;
using TeacherApi.Model;

namespace TeacherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherBL service;
        public TeacherController(ITeacherBL bl)
        {
            this.service = bl;
        }

        public Teacher[] Get()
        {
            return this.service.GetStudents();
        }

    }
}
