namespace LinqWhereProject
{
    class Person
    {
        public string? Name { get; set; }
        public DateTime BirthDay { set; get; }
    }

    class Student : Person
    {
        public List<string>? Subject { set; get; }
    }

    class Employe : Person
    {
        public float Salary { set; get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            //string[] strs = { "hello", "people", "book", "boy", "economics" };
            //var strOne = from s in strs
            //             where s.Length <= 5
            //             select s;

            //var strTwo = strs.Where(s => s.Length <= 5);

            //foreach (var s in strOne)
            //    Console.WriteLine(s);
            //Console.WriteLine(new String('-', 10));

            //foreach (var s in strTwo)
            //    Console.WriteLine(s);
            //Console.WriteLine(new String('-', 10));

            var students = new List<Student>
            {
                new Student(){Name = "Bob",
                            BirthDay = new DateTime(1999, 5, 25),
                            Subject = new List<string>{ "Math", "Physic", "Liter", "Program" } },
                new Student(){Name = "Tom",
                            BirthDay = new DateTime(2002, 6, 3),
                            Subject = new List<string>{ "Math", "Bio", "Program" } },
                new Student(){Name = "Sam",
                            BirthDay = new DateTime(2005, 11, 16),
                            Subject = new List<string>{ "Physic", "Bio", "Program" } },
                new Student(){Name = "Jim",
                            BirthDay = new DateTime(2001, 3, 8),
                            Subject = new List<string>{ "Math", "Program" } },
                new Student(){Name = "Tim",
                            BirthDay = new DateTime(2003, 7, 10),
                            Subject = new List<string>{ "Bio", "Physic", "Liter" } }
            };

            var students20One = from s in students
                             where (DateTime.Now - s.BirthDay).Days <= 365 * 21
                             select s;

            foreach (var s in students20One)
                Console.WriteLine($"{s.Name} {s.BirthDay}");
            Console.WriteLine(new String('-', 10));

            var students20Two = students.Where(s => (DateTime.Now - s.BirthDay).Days <= 365 * 21);

            foreach (var s in students20Two)
                Console.WriteLine($"{s.Name} {s.BirthDay}");
            Console.WriteLine(new String('-', 10));

            var students20PhysicOne = from s in students
                                      from subj in s.Subject
                                      where (DateTime.Now - s.BirthDay).Days <= 365 * 21
                                      where subj == "Physic"
                                      select s;

            foreach (var s in students20PhysicOne)
                Console.WriteLine($"{s.Name} {s.BirthDay}");
            Console.WriteLine(new String('-', 10));

            var students20PhysicTwo = students.SelectMany(s => s.Subject,
                                                          (s, subj) => new { Student = s, Subject = subj })
                                              .Where(t => (DateTime.Now - t.Student.BirthDay).Days <= 365 * 21
                                                        && t.Subject == "Physic")
                                              .Select(t => t.Student);

            foreach (var s in students20PhysicTwo)
                Console.WriteLine($"{s.Name} {s.BirthDay}");
            Console.WriteLine(new String('-', 10));

            var persons = new List<Person>
            {
                new Student{ Name = "Bill" },
                new Person{ Name = "Nick" },
                new Employe{ Name = "Mike" },
                new Student{ Name = "Susan" },
                new Employe{ Name = "Kevin" },
            };

            var personsStudents = persons.OfType<Student>();

            foreach (var s in personsStudents)
                Console.WriteLine($"{s.Name}");
            Console.WriteLine(new String('-', 10));
        }
    }
}