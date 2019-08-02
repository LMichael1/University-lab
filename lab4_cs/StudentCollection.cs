using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class StudentCollection
    {
        public event StudentListHandler StudentsCountChanged;
        public event StudentListHandler StudentReferenceChanged;
        private List<Student> students = new List<Student>();
        public string CollectionName { get; set; }
        public StudentCollection(string name)
        {
            CollectionName = name;
        }
        public Student this[int index]
        {
            get
            {
                return students[index];
            }
            set
            {
                students[index] = value;
                StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Изменен", students[index]));
            }
        }
        public void AddDefaults()
        {
            for (int i=0; i<3; i++)
            {
                students.Add(new Student());
                StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавлен", new Student()));
            }
        }
        public void AddStudents(params Student[] stud)
        {
            for (int i=0; i<stud.Length; i++)
            {
                students.Add(stud[i]);
                StudentsCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавлен", stud[i]));
            }
        }
        public override string ToString()
        {
            string a = "";
            for (int i = 0; i<students.Count; i++)
            {
                a += students[i].ToString();
            }
            return a;
        }
        public string ToShortString()
        {
            string a = "";
            for (int i = 0; i < students.Count; i++)
            {
                a += students[i].ToShortString();
            }
            return a;
        }
        public void SortLastName()
        {
            students.Sort();
        }
        public void SortDate()
        {
            students.Sort(new Person());
        }
        public void SortAverage()
        {
            students.Sort(new AverageComparer());
        }
        public bool Remove (int j)
        {
            if (students[j] != null)
            {
                if (StudentsCountChanged != null)
                {
                    StudentsCountChanged(this, new StudentListHandlerEventArgs(CollectionName, "Удален", students[j]));
                }
                students.RemoveAt(j);
                return true;
            }
            return false;
        }
    }
}
