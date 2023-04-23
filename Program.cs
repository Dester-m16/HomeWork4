using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    private string name;
    private DateTime birthYear;

    public Person()
    {
        // default constructor
    }

    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    public int Age()
    {
        int age = DateTime.Now.Year - birthYear.Year;
        if (DateTime.Now.DayOfYear < birthYear.DayOfYear)
        {
            age--;
        }
        return age;
    }

    public void Input()
    {
        Console.Write("Enter name: ");
        name = Console.ReadLine();
        Console.Write("Enter birth year (yyyy): ");
        int year;
        if (int.TryParse(Console.ReadLine(), out year))
        {
            birthYear = new DateTime(year, 1, 1);
        }
        else
        {
            Console.WriteLine("Invalid year.");
        }
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public override string ToString()
    {
        return $"Name: {name}, Birth Year: {birthYear:yyyy}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person person1, Person person2)
    {
        return person1.Name == person2.Name;
    }

    public static bool operator !=(Person person1, Person person2)
    {
        return !(person1 == person2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person[] people = new Person[6];

        for (int i = 0; i < people.Length; i++)
        {
            people[i] = new Person();
            people[i].Input();
        }

        foreach (Person person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age()}");
        }

        foreach (Person person in people)
        {
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        Console.WriteLine("People:");
        foreach (Person person in people)
        {
            person.Output();
        }

        Console.WriteLine("People with same names:");
        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine($"Person {i + 1} and Person {j + 1} have the same name.");
                }
            }
        }

        Console.ReadLine();
    }
}