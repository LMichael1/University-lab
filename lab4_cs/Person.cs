using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4_cs
{
    class Person : IDateAndCopy, IComparable, IComparer<Person>
    {
        protected string firstname;
        protected string lastname;
        protected DateTime birthday;
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public DateTime Date
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public int BirthYear
        {
            get { return birthday.Year; }
            set { birthday = new DateTime(value, birthday.Month, birthday.Day); }
        }
        public Person(string firstname, string lastname, DateTime birthday)
        {
            FirstName = firstname;
            LastName = lastname;
            Date = birthday;
        }
        public Person()
        {
            FirstName = "noname";
            LastName = "noname";
            Date = new DateTime(2000, 01, 01);
        }
        public override string ToString()
        {
            return "Имя: " + FirstName + " Фамилия: " + LastName + " Дата рождения: " + Date + "\n";
        }
        public string ToShortString()
        {
            return "Имя: " + FirstName + " Фамилия: " + LastName + "\n";
        }
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                return this.ToString() == obj.ToString();
            }
            else return false;
        }
        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return !p1.Equals(p2);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public virtual object DeepCopy()
        {
            Person obj = new Person(this.FirstName, this.LastName, this.Date);
            return obj;
        }
        int IComparable.CompareTo(object obj)
        {
            Person tmp = obj as Person;
            if (tmp != null)
            {
                return this.LastName.CompareTo(tmp.LastName);
            }
            else throw new ArgumentException("Obj isn't Person");
        }
        int IComparer<Person>.Compare(Person t1, Person t2)
        {
            if (t1 != null && t2 != null)
            {
                return t1.Date.CompareTo(t2.Date);
            }
            else throw new ArgumentException("Obj isn't Person");
        }
    }
}
