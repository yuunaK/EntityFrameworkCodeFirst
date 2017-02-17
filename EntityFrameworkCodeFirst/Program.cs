using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                var student1 = new Student() { StudentName = "Penelope" };
                var student2 = new Student() { StudentName = "Erin" };
                var student3 = new Student() { StudentName = "Jane" };

                var subject1 = new Subject() { SubjectName = "Mathematics" };
                var subject2 = new Subject() { SubjectName = "Science" };
                var subject3 = new Subject() { SubjectName = "Art History" };

                student1.StudentSubjects.Add(subject1);
                student2.StudentSubjects.Add(subject2);
                student3.StudentSubjects.Add(subject3);

                db.Students.Add(student1);
                db.Students.Add(student2);
                db.Students.Add(student3);

                db.SaveChanges();

            }
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public virtual List<Subject> StudentSubjects { get; set; }

        public Student()
        {
            this.StudentSubjects = new List<Subject>();
        }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public virtual Student Student { get; set; }
    }

    class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
