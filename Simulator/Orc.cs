namespace Simulator;

public class Orc : Creature
{

    private int _rage;

    private int _huntCount;
    public override char Symbol => 'O';

    public int Rage
    {
        get => _rage;
        set
        {
            if (value < 0)
                _rage = 0;
            else if (value > 10)
                _rage = 10;
            else
                _rage = value;
        }
    }

    public void Hunt()
    {
        _huntCount++;
        if (_huntCount % 2 == 0) 
        {
            Rage++;
        }
    }

    public override int Power => 7 * Level + 3 * Rage;

    public Orc() : base() { }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";

    public override string Info
    {
        get => $"Orc: {Name} [{Level}][{Rage}]";
    }

}