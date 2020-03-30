using System;

namespace Project
{
    public class Student : Human
    {
        public enum Year
        {
            First = 1,
            Second=2,
            Third=3,
            Fourth=4
        }

        protected internal static int M;

        public Student(string name, string surname, string patronymic, int age, Genders gender, string university,
            Year course, double averageMark) : base(
            name, surname, patronymic, age, gender)
        {
            University = university;
            Course = course;
            AverageMark = averageMark;
        }

        public double AverageMark { private set; get; }
        public Year Course { private set; get; }
        public string University { private set; get; }

        public override void Information()
        {
            base.Information();
            Console.WriteLine("University: {0}\nCourse: {1}\nAverage mark: {2}", University, Course, AverageMark);
        }

        protected void CopyData(Student a)
        {
            base.CopyData(a);
            University = a.University;
            Course = a.Course;
            AverageMark = a.AverageMark;
        }

        public static void Deducting(ref Student[] students, int n)
        {
            for (var i = n; i < M; i++) students[i].CopyData(students[i + 1]);
            M--;
        }
    }
}