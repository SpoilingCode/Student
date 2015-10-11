using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudent
{
    class Program
    {       
            
        const int maxNumberStudents = 20;
            static int numberStudents = 0;
            static Student[] students = new Student[maxNumberStudents];
            static bool stateKeyBoardInput = true;

            static void Main(string[] args)
            {
                bool flag = true;

                while (flag)
                {

                    Console.WriteLine("\nВыберите действие:\n");
                    Console.WriteLine("1 - Тестовое создание объектов класса Студент");
                    Console.WriteLine("2 - Тестовое использование свойств класса Студент и метода ввода");
                    Console.WriteLine("3 - Формирование нового списка студентов");
                    Console.WriteLine("4 - Добавление данных о студенте");
                    Console.WriteLine("5 - Вывод списка студентов на экран");
                    Console.WriteLine("6 - Операция класса: Вычисление разницы в возрасте (в днях) для двух студентов");
                    Console.WriteLine("7 - Поиск в массиве всех студентов заданного года рождения");
                    Console.WriteLine("8 - Удаление студента с заданной фамилией из массива");
                    Console.WriteLine("0 - Выход");

                    try
                    {
                        if (stateKeyBoardInput)

                            for (int i = 0; i < maxNumberStudents; i++)
                            {
                                students[i] = new Student();



                            }

                        int choose = int.Parse(Console.ReadLine());

                        switch (choose)
                        {

                            case 0:
                                {
                                    flag = false;
                                    Console.WriteLine("Программа завершила работу.");
                                    break;
                                }

                            case 1:
                                {

                                    Console.WriteLine("Количество созданных объектов = " + Student.quantityObjects);
                                    Console.WriteLine("\nДемонстрируется работа четырех конструкторов: ");

                                    Student firstStudent = new Student();
                                    firstStudent.outputDataAboutStudents();

                                    Student secondStudent = new Student("Иван", "Николаевич", "Тополев", 10, 12, 1990);
                                    secondStudent.outputDataAboutStudents();

                                    Student thirdStudent = new Student("Максимов");
                                    thirdStudent.outputDataAboutStudents();

                                    Console.WriteLine("\nКоличество созданных объектов = " + Student.quantityObjects);
                                    break;

                                }

                            case 2:
                                {
                                    Console.WriteLine(" Для демонстрации свойств класса и метода вывода создайте студента. ");
                                    Student student = new Student();
                                    student.inputDataAboutStudents();

                                    Console.WriteLine("\nСоздан студент:");
                                    student.outputDataAboutStudents();

                                    student.Name = "Василий";
                                    student.Patronymic = "Федорович";
                                    student.LastName = "Астафьев";
                                    student.Day_birth = 15;
                                    student.Month_birth = 10;
                                    student.Year_birth = 1994;

                                    Console.WriteLine("\nДанные студента изменены:");
                                    Console.WriteLine("ФИО: {0} {1} {2}   Дата Рождения:{3}.{4}.{5}", student.LastName, student.Name, student.Patronymic,
                                                                                                       student.Day_birth, student.Month_birth, student.Year_birth);

                                    break;

                                }

                            case 3:
                                {
                                    if (numberStudents == 0) new_array();
                                    else Console.WriteLine("Список уже сформирован, Вы можете только добавить студента");
                                    break;
                                }
                            case 4: addStudent(); break;
                            case 5: outputArrayStudents(); break;
                            case 6:
                                {

                                    Student s1 = new Student();
                                    s1.inputDataAboutStudents();
                                    Console.WriteLine("\nСоздан студент: ");
                                    s1.outputDataAboutStudents();

                                    Student s2 = new Student();
                                    s2.inputDataAboutStudents();
                                    Console.WriteLine("\nСоздан студент: ");
                                    s2.outputDataAboutStudents();
                                    Console.WriteLine("Разница в возрасте двух студентов: {0} дн.", Math.Abs(s1 - s2));
                                    break;

                                }
                            case 7:
                                {
                                    Console.WriteLine("\nВведите год рождения студента, данные о котором Вы хотите найти:  ");
                                    int readYearBirth = int.Parse(Console.ReadLine());
                                    Student.findStudentsByYearBirth(students, numberStudents, readYearBirth);
                                    break;
                                }
                            case 8:
                                {
                                    Console.WriteLine("Введите фамилию студента, которого хотите удалить: ");
                                    string readSurname = Console.ReadLine();
                                    removeStudentInArray(readSurname);

                                    break;
                                }
                            default: Console.WriteLine("Ошибка ввода\n"); break;

                        }

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Exception:{0}\nFile:{1}\nLocation:{2}\n{3}", ex.Message, ex.Source, ex.TargetSite, ex.StackTrace);
                        Console.WriteLine("Для продолжения нажмите Enter");
                        Console.ReadKey();

                    }



                }
            }

            static void addStudent()
            {

                if (numberStudents < maxNumberStudents)
                {

                    students[numberStudents] = new Student();
                    students[numberStudents].inputDataAboutStudents();
                    numberStudents++;

                }
                else Console.WriteLine("Невозможно добавить студента.Массив заполнен.");

            }

            static void outputArrayStudents()
            {

                if (numberStudents == 0) Console.WriteLine("Нет студентов в списке");

                else
                {

                    for (int i = 0; i < numberStudents; i++)
                    {

                        students[i].outputDataAboutStudents();

                    }

                }

            }


            static void removeStudentInArray(string readLastName)
            {
                Student[] arrStudent = new Student[students.Length];

                for (int i = 0, j = 0; i < students.Length; i++)
                {
                    if (students[i].LastName != readLastName)
                    {
                        arrStudent[j] = students[i];
                        arrStudent[j].outputDataAboutStudents();
                        j++;
                    }
                }
            }


            static Student[] Filter(string readSurname)
            {
                return students.Where(s => s.LastName != readSurname).ToArray();
            }


            static void new_array()
            {

                Console.WriteLine("Будете вводить данные с клавиатуры?(y/n)");
                char readStr = char.Parse(Console.ReadLine());

                if (readStr == 'y' || readStr == 'Y')
                {

                    Console.WriteLine("Введите количество студентов < " + maxNumberStudents);
                    int quantityStudents = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= quantityStudents; i++)
                    {
                        addStudent();
                    }

                    Console.WriteLine("\nФормирование списка завершено.");
                }
                else
                {
                    stateKeyBoardInput = false;
                    Student[] arrayStudents = 
              {
                  new Student("Александр", "Петрович", "Иванов", 13, 5, 1992),
                  new Student("Валерий" , "Михайлович", "Островский", 14, 10, 1996),
                  new Student("Дмитрий", "Александрович", "Колосов", 21, 5, 1996),
                  new Student("Валентин" , "Андреевич", "Ломов", 11, 1, 1993),
                  new Student("Леонид", "Федорович", "Мамонов", 3, 5, 1992),
                  new Student("Владимир" , "Константинович", "Носов", 27, 12, 1999),
                  new Student("Вадим" , "Максимович", "Щуров", 2, 4, 1999)
                  
              };

                    for (int i = 0; i < arrayStudents.Length; i++)
                    {
                        students[i] = arrayStudents[i];
                        numberStudents++;
                    }

                    Console.WriteLine("\nСписок студентов сформирован из заданного массива ");
                }

            }

        }
    }

