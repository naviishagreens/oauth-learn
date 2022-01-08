using naviisha.common.DL;
using StudentApi.Model;

namespace StudentApi.BL
{
    public class StudentBL : IStudentBL
    {
        IFaker fakerApi;
        Student[]? students = null;

        public StudentBL(IFaker fakerApi)
        {
            this.fakerApi = fakerApi;
        }

        public Student[] GetStudents()
        {
            if(students == null)
            {
                // not thread safe right now
                students = Enumerable.Range(1, 50).Select(index => new Student
                {
                    Age = fakerApi.GetAge(),
                    ClassName = fakerApi.GetClass(),
                    Name = fakerApi.GetName(),
                    Subjects = Enumerable.Range(1, 5).Select(_ => fakerApi.GetSubject()).ToArray(),
                })
            .ToArray();
            }

            return students;
        }
    }
}
