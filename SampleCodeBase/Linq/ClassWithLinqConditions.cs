using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SampleCodeBase.Linq
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class ClassWithLinqConditions
    {
        public ClassWithLinqConditions()
        {
            Persons = new List<Person>();
        }

        public List<Person> Persons { get; set; }

        public void SelectPersonsNamedAsJohn(IEnumerable<Person> persons)
        {
            // Detect this
            var personsNamedAsJohn = persons.Where(person => person.Name == "John").ToList();

            // Do stuff
        }

        public void SelectPropertyPersonsNamedAsJohn(int x)
        {
            var personsNamedAsJohn = Persons.Where(person => person.Name == "John").ToList();
        }


        public void SelectPersonsNamedAsGeorge(Person[] persons)
        {
            // Detect this
            var personsNamedAsGeorge = persons.Where(person => person.Name == "George").ToList();

            // Do stuff
        }

        public void SelectPersonsNamedAsNick(IList<Person> persons)
        {
            // Detect this
            var personsNamedAsNick = persons.Where(person => person.Name == "Nick").ToList();

            // Do stuff
        }

        public void SelectPersonsNotNamedAsNick(IList<Person> persons)
        {
            // Detect this
            var personsNamedAsNick = persons.Where(person => person.Name != "Nick").ToList();

            // Do stuff
        }

        public void SelectAgesOf18(IList<Person> persons)
        {
            // Detect this
            var personsNamedAsNick = persons.Where(person => person.Age == 18);

            // Do stuff
        }

        public void SelectAgesOfNot18(IList<Person> persons)
        {
            // Detect this
            var personsNamedAsNick = persons.Where(person => person.Age != 18);

            // Do stuff
        }

        public IEnumerable<Person> GetPersonsNamedAsJohn(IList<Person> persons)
        {
            return persons.Where(person => person.Name == "John");
        }

        public IEnumerable<Person> GetPersonsNamedAsJohnReturnAssignment(IList<Person> persons)
        {
            var personsNamedAsJohn = persons.Where(person => person.Name == "John");
            return personsNamedAsJohn;
        }

        public IEnumerable<Person> GetPersonsOtherThan18(IList<Person> persons)
        {
            // Detect this
            var personsFiltered = persons.Where(person => person.Age != 18);
            return personsFiltered;
        }

        public IList<Person> GetPersonsReturnList(IList<Person> persons, string x)
        {
            return persons.Where(person => person.Name == "John").ToList();
        }

        public IList<Person> GetPersonsReturnVariableToList(IList<Person> persons, string x)
        {
            var personsNamedAsJohn = persons.Where(person => person.Name == "John");
            return personsNamedAsJohn.ToList();
        }

        public IEnumerable<Person> GetPersonsNamedAsJohnReturnAssignmentIfFileExistsStatement(IList<Person> persons)
        {
            if (File.Exists("a.txt"))
            {
                Console.WriteLine("Test");
            }
            var personsNamedAsJohn = persons.Where(person => person.Name == "John");
            return personsNamedAsJohn;
        }
    }
}
