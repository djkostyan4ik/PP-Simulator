using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    // Default value "Unknown"
    private string _description = "Unknown";
    public string Description 
    {
        get => _description;
        set
        {
            // Cannot have spaces at the beginning or end - remove excess
            _description = value?.Trim() ?? "Unknown";


            // Must be at least 3 characters long (fill in the missing ones with #)
            if (_description.Length < 3)
                _description = _description.PadRight(3, '#');


            // It can be a maximum of 15 characters (trim if too long, remove any spaces at the end)
            if (_description.Length > 15)
            {
                _description = _description.Substring(0, 15).TrimEnd();


                // Check if it has at least 3 characters after that and add # signs if necessary
                if (_description.Length < 3)
                    _description = _description.PadRight(3, '#');
            }

            // If the first character is a lowercase letter then convert it to uppercase
            if (char.IsLower(_description[0]))
                _description = char.ToUpper(_description[0]) + _description.Substring(1);
        }
    }
    public uint Size { get; set; } = 3;


    // Info property readonly
    public virtual string Info => $"{Description} <{Size}>";


    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}

