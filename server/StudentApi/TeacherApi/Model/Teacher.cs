﻿namespace TeacherApi.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? Name { get; set; }
        public string[]? Subjects { get; set; }
    }
}
