using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection col1 = new StudentCollection("Коллекция 1");
            StudentCollection col2 = new StudentCollection("Коллекция 2");
            Journal j1 = new Journal();
            Journal j2 = new Journal();
            col1.StudentsCountChanged += j1.StudentsCountChanged;
            col1.StudentReferenceChanged += j1.StudentReferenceChanged;
            col1.StudentReferenceChanged += j2.StudentReferenceChanged;
            col2.StudentReferenceChanged += j2.StudentReferenceChanged;
            col1.AddDefaults();
            col2.AddDefaults();
            col1.Remove(0);
            col2.Remove(1);
            col1[0] = new Student(new Person ("Ivan", "Ivanov", DateTime.Parse("01.01.2005")), Education.SecondEducation, 3);
            col2[0] = new Student(new Person("Ivan 2", "Ivanov", DateTime.Parse("01.01.2003")), Education.SecondEducation, 4);
            Console.WriteLine("Журнал 1: \n");
            Console.WriteLine(j1.ToString() + "\n\n");
            Console.WriteLine("Журнал 2: \n");
            Console.WriteLine(j2.ToString());
            Console.ReadLine();
        }
    }
}
