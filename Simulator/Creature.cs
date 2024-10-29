namespace Simulator;
 public class Creature
 {

    // Automatic properties
    public string Name { get; set; }
    public int Level { get; set; }


    // Constructor that accepts initial values ​​for Name and Level
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }


    // Constructor parameterless
    public Creature()
    { }


    // SayHi method
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}!");
    }


    // Readonly property Info
    public string Info => $"{Name} [{Level}]";
}
