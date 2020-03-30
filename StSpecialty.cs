using System;

namespace Project
{
    public class StSpecialty : Student
    {
        protected internal static int S;
        private string _faculty;
        private int _personalNumber;
        private string _specialty;

        public StSpecialty(string name, string surname, string patronymic, int age, Genders gender, string university,
            Year course, double averageMark, string faculty, int personalNumber, string specialty) :
            base(name, surname, patronymic, age, gender, university, course, averageMark)
        {
            _faculty = faculty;
            _personalNumber = personalNumber;
            _specialty = specialty;
        }

        public override void Information()
        {
            base.Information();
            Console.WriteLine("Faculty: {0}\nSpecialty: {1}\nPersonal number: {2}", _faculty, _specialty, _personalNumber);
        }

        private void CopyData(StSpecialty a)
        {
            base.CopyData(a);
            _faculty = a._faculty;
            _specialty = a._specialty;
            _personalNumber = a._personalNumber;
        }

        public static void Deducting(ref StSpecialty[] specialty, int n)
        {
            for (var i = n; i < M; i++) specialty[i].CopyData(specialty[i + 1]);
            S--;
        }
    }
}