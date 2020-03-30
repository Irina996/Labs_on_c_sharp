using System;

namespace Project
{
    internal static class Program
    {
        private static void Functions()
        {
            Console.WriteLine(
                "1.Add information about new human.\n2.Information about human.\n3.Add information about new student.\n" +
                "4.Information about student.\n5.List all humans in base.\n6.Number of humans in base.\n" +
                "7.Deduct student.\n8.Take human in student.\n9.Add information about specialty student\n" +
                "10.Information about specialty student.\n11.Deduct specialty student.\n12.End program.");
        }

        private static void AddHuman(out string name, out string surname, out string patronymic, out int age,
            out Human.Genders gender)
        {
            Console.WriteLine("Name");
            name = Console.ReadLine();
            Console.WriteLine("Surname");
            surname = Console.ReadLine();
            Console.WriteLine("Patronymic name");
            patronymic = Console.ReadLine();
            Console.WriteLine("Age");
            while (!int.TryParse(Console.ReadLine(), out age))
                Console.WriteLine("ERROR. Enter one more time.");
            Console.WriteLine("Gender");
            Enum.TryParse(Console.ReadLine(), out gender);
            while (!Enum.IsDefined(typeof(Human.Genders), gender))
            {
                Console.WriteLine("ERROR. Enter one more time.");
                Enum.TryParse(Console.ReadLine(), out gender);
            }
        }

        private static void AddStudent(out string university, out Student.Year course, out double averagemark)
        {
            Console.WriteLine("University: ");
            university = Console.ReadLine();
            Console.WriteLine("Course: ");
            Enum.TryParse(Console.ReadLine(), out course);
            while (!Enum.IsDefined(typeof(Student.Year), course))
            {
                Console.WriteLine("ERROR. Enter one more time.");
                Enum.TryParse(Console.ReadLine(), out course);
            }

            Console.WriteLine("Average mark: ");
            while (!double.TryParse(Console.ReadLine(), out averagemark))
                Console.WriteLine("ERROR. Enter one more time.");
        }

        private static void Main()
        {
            var p = true;
            var humans = new Human[20];
            var students = new Student[20];
            var specialities = new StSpecialty[20];
            Functions();
            while (p)
            {
                string name, surname, patronymic, university;
                int age;
                Human.Genders gender;
                Student.Year course;
                double averagemark;
                Console.WriteLine("Chose number of function.");
                var func = Convert.ToInt32(Console.ReadLine());
                int number;
                switch (func)
                {
                    case 1:
                        Human.N++;
                        if (Human.N < 20)
                        {
                            AddHuman(out name, out surname, out patronymic, out age, out gender);
                            humans[Human.N] = new Human(name, surname, patronymic, age, gender);
                        }
                        else
                        {
                            Console.WriteLine("Too many people, it is impossible to add another one.");
                            Human.N--;
                        }

                        break;
                    case 2:
                        Console.WriteLine("Number of the human");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number > Human.N || number <= 0)
                            Console.WriteLine("Error. Incorrect input");
                        else
                            humans[number].Information();
                        break;
                    case 3:
                        Student.M++;
                        if (Student.M < 20)
                        {
                            AddHuman(out name, out surname, out patronymic, out age, out gender);
                            AddStudent(out university, out course, out averagemark);
                            students[Student.M] = new Student(name, surname, patronymic, age, gender, university,
                                course, averagemark);
                        }
                        else
                        {
                            Console.WriteLine("To many students.");
                            Student.M--;
                        }

                        break;
                    case 4:
                        Console.WriteLine("Number of the student.");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number > Student.M || number <= 0)
                            Console.WriteLine("ERROR. Incorrect input.");
                        else
                            students[number].Information();
                        break;
                    case 5:
                        if (Human.N > 0)
                        {
                            Console.WriteLine("All Humans are:");
                            for (var i = 1; i <= Human.N; i++)
                            {
                                Console.WriteLine("{0}", i);
                                humans[i].ListHumans(humans[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("NO humans in base.");
                        }

                        break;
                    case 6:
                        Human.Population();
                        break;
                    case 7:
                        Console.WriteLine("Enter number of student.");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number > 0 && number <= Student.M)
                        {
                            Human.N++;
                            humans[Human.N] = new Human(students[number].Name, students[number].Surname,
                                students[number].Patronymic, students[number].Age, students[number].Gender);
                            Student.Deducting(ref students, number);
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                        }

                        break;
                    case 8:
                        Console.WriteLine("Enter number of human.");
                        number = Convert.ToInt32(Console.ReadLine());
                        Student.M++;
                        AddStudent(out university, out course, out averagemark);
                        students[Student.M] = new Student(humans[number].Name, humans[number].Surname,
                            humans[number].Patronymic,
                            humans[number].Age, humans[number].Gender, university, course, averagemark);
                        Human.Clear(ref humans, number);
                        break;
                    case 9:
                        StSpecialty.S++;
                        if (StSpecialty.S < 20)
                        {
                            AddHuman(out name, out surname, out patronymic, out age, out gender);
                            AddStudent(out university, out course, out averagemark);
                            Console.WriteLine("Faculty: ");
                            var faculty = Console.ReadLine();
                            Console.WriteLine("Specialty: ");
                            var specialty = Console.ReadLine();
                            Console.WriteLine("Personal number: ");
                            int personalnumber;
                            while (!int.TryParse(Console.ReadLine(), out personalnumber))
                                Console.WriteLine("ERROR. Enter one more time.");
                            specialities[StSpecialty.S] = new StSpecialty(name, surname, patronymic, age, gender,
                                university, course, averagemark, faculty, personalnumber, specialty);
                        }
                        else
                        {
                            Console.WriteLine("To many specialty students.");
                            StSpecialty.S--;
                        }

                        break;
                    case 10:
                        Console.WriteLine("Number of the specialty student.");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number > StSpecialty.S || number <= 0)
                            Console.WriteLine("ERROR. Incorrect input.");
                        else
                            specialities[number].Information();
                        break;
                    case 11:
                        Console.WriteLine("Enter number of specialty student.");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number > 0 && number <= StSpecialty.S)
                        {
                            Student.M++;
                            students[Student.M] = new Student(specialities[number].Name, specialities[number].Surname,
                                specialities[number].Patronymic, specialities[number].Age, specialities[number].Gender,
                                specialities[number].University, specialities[number].Course,
                                specialities[number].AverageMark);
                            StSpecialty.Deducting(ref specialities, number);
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                        }

                        break;
                    case 12:
                        p = false;
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }
            }
        }
    }
}