using System;

namespace Project
{
    public class Human
    {
        public enum Genders
        {
            male,
            female
        }
        
        protected internal static int N;

        public Human(string name, string surname, string patronymic, int age, Genders gender)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Age = age;
            Gender = gender;
        }

        public int Age { get; private set; }
        public Genders Gender { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public string Surname { get; private set; }

        public virtual void Information()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nPatronymic name: {2}\nAge: {3}\nGender:{4}", Name, Surname,
                Patronymic, Age, Gender);
        }

        public static void Population()
        {
            Console.WriteLine(N);
        }

        public void ListHumans(Human a)
        {
            a.Information();
        }

        protected void CopyData(Human a)
        {
            Name = a.Name;
            Surname = a.Surname;
            Patronymic = a.Patronymic;
            Age = a.Age;
            Gender = a.Gender;
        }

        public static void Clear(ref Human[] humans, int n)
        {
            for (var i = n; i < N; i++) humans[i].CopyData(humans[i + 1]);
            N--;
        }
    }
}