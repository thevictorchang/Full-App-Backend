using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MSAUniApp.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MSAUniAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public class MyConfiguration : DbMigrationsConfiguration<MSAUniAppContext>
        {

            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(MSAUniAppContext context)
            {
                var students = new List<Student>
                {
                    new Student { FirstMidName = "Carson",   LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2010-09-01") },
                    new Student { FirstMidName = "Meredith", LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Arturo",   LastName = "Anand",
                        EnrollmentDate = DateTime.Parse("2013-09-01") },
                    new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Yan",      LastName = "Li",
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Peggy",    LastName = "Justice",
                        EnrollmentDate = DateTime.Parse("2011-09-01") },
                    new Student { FirstMidName = "Laura",    LastName = "Norman",
                        EnrollmentDate = DateTime.Parse("2013-09-01") },
                    new Student { FirstMidName = "Nino",     LastName = "Olivetto",
                        EnrollmentDate = DateTime.Parse("2005-08-11")}
                };
                students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
                context.SaveChanges();

                /*
                var courses = new List<Course>
                {
                    new Course {ID = 1050, Title = "Chemistry",      Credits = 3, },
                    new Course {ID = 4022, Title = "Microeconomics", Credits = 3, },
                    new Course {ID = 4041, Title = "Macroeconomics", Credits = 3, },
                    new Course {ID = 1045, Title = "Calculus",       Credits = 4, },
                    new Course {ID = 3141, Title = "Trigonometry",   Credits = 4, },
                    new Course {ID = 2021, Title = "Composition",    Credits = 3, },
                    new Course {ID = 2042, Title = "Literature",     Credits = 4, }
                };
                courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
                context.SaveChanges();
                */

                /*
                var enrollments = new List<Enrollment>
                {
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,
                        ID = courses.Single(c => c.Title == "Chemistry" ).ID,
                        Grade = Grade.A
                    },
                     new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,
                        ID = courses.Single(c => c.Title == "Microeconomics" ).ID,
                        Grade = Grade.C
                     },
                     new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,
                        ID = courses.Single(c => c.Title == "Macroeconomics" ).ID,
                        Grade = Grade.B
                     },
                     new Enrollment {
                         StudentID = students.Single(s => s.LastName == "Alonso").ID,
                        ID = courses.Single(c => c.Title == "Calculus" ).ID,
                        Grade = Grade.B
                     },
                     new Enrollment {
                         StudentID = students.Single(s => s.LastName == "Alonso").ID,
                        ID = courses.Single(c => c.Title == "Trigonometry" ).ID,
                        Grade = Grade.B
                     },
                     new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alonso").ID,
                        ID = courses.Single(c => c.Title == "Composition" ).ID,
                        Grade = Grade.B
                     },
                     new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Anand").ID,
                        ID = courses.Single(c => c.Title == "Chemistry" ).ID
                     },
                     new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Anand").ID,
                        ID = courses.Single(c => c.Title == "Microeconomics").ID,
                        Grade = Grade.B
                     },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                        ID = courses.Single(c => c.Title == "Chemistry").ID,
                        Grade = Grade.B
                     },
                     new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Li").ID,
                        ID = courses.Single(c => c.Title == "Composition").ID,
                        Grade = Grade.B
                     },
                     new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Justice").ID,
                        ID = courses.Single(c => c.Title == "Literature").ID,
                        Grade = Grade.B
                     }
                };

                foreach (Enrollment e in enrollments)
                {
                    var enrollmentInDataBase = context.Enrollments.Where(
                        s =>
                             s.Student.ID == e.StudentID &&
                             s.Course.ID == e.ID).SingleOrDefault();
                    if (enrollmentInDataBase == null)
                    {
                        context.Enrollments.Add(e);
                    }
                }
                context.SaveChanges();
                */
            }
            
        }
        

        public MSAUniAppContext() : base("name=MSAUniAppContext")
        {
            if (!Database.Exists("MSAUniAppContext"))
            {
                // Need to initialize database with configuration 
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<MSAUniAppContext, MyConfiguration>());
            }
            }

        public System.Data.Entity.DbSet<MSAUniApp.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<MSAUniApp.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<MSAUniApp.Models.Enrollment> Enrollments { get; set; }

        public System.Data.Entity.DbSet<MSAUniApp.Models.Courseitem> Courseitems { get; set; }
    }
}
