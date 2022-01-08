using naviisha.common.DL;
using TeacherApi.Model;

namespace TeacherApi.BL
{
    public class TeacherBL : ITeacherBL
    {
        IFaker fakerApi;
        Teacher[]? teachers = null;

        public TeacherBL(IFaker fakerApi)
        {
            this.fakerApi = fakerApi;
        }

        public Teacher[] GetStudents()
        {
            if(teachers == null)
            {
                // not thread safe right now
                teachers = Enumerable.Range(1, 50).Select(index => new Teacher
                {
                    Id = fakerApi.GetId(),
                    Age = fakerApi.GetAge(),
                    Name = fakerApi.GetName(),
                    Subjects = Enumerable.Range(1, 5).Select(_ => fakerApi.GetSubject()).ToArray(),
                })
            .ToArray();
            }

            return teachers;
        }
    }
}
