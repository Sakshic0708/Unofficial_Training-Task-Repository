using Newtonsoft.Json;
using System;
using System.IO;


public class City
{
    public string Name { get; set; }
    public int Population { get; set; }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public City City { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, City: {City.Name}, Population: {City.Population}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Name");
        var name = Console.ReadLine();
        Console.WriteLine("Enter Age");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter City Name");
        var CityName = Console.ReadLine();
        Console.WriteLine("Enter Population");
        int Population = Convert.ToInt32(Console.ReadLine());

        // create a person object
        var person = new Person
        {
            Name = name,
            Age = age,
            City = new City { Name = CityName, Population = Population }
        };

        // serialize
        var json = JsonConvert.SerializeObject(person);
        System.IO.File.WriteAllText("person.json", json);

        // deserialize
        var jsonFromFile = File.ReadAllText("person.json");
        var personFromFile = JsonConvert.DeserializeObject<Person>(jsonFromFile);
        Console.WriteLine(personFromFile.ToString());
    }
}