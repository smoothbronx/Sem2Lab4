namespace lab4;

public class Sign : IComparable<Sign>, ICloneable
{
    private readonly string[] _signs =
    {
        "овен", "телец", "близнецы", "рак", "лев", "дева", "весы", "скорпион", "стрелец", "козерог", "водолей", "рыбы"
    };
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ZodiacSign { get; set; }
    public int[] Birthdate { get; set;  }

    public Sign(int id, string name, string surname, string zodiacSign, int[] birthdate)
    {
        if (!_signs.Contains(zodiacSign.ToLower()))
            throw new ArgumentException("Sign must be contains in signs");
        if (birthdate.Length != 3)
            throw new ArgumentException("Lenght of birthdate must be equal 3");
            
        Id = id;
        Name = name;
        Surname = surname;
        ZodiacSign = zodiacSign;
        Birthdate = birthdate;
    }

    public int CompareTo(Sign? other)
    {
        if (other == null) return 1;
        var thisSignIndex = Array.IndexOf(_signs, ZodiacSign.ToLower());
        var otherSignIndex = Array.IndexOf(_signs, other.ZodiacSign.ToLower());
        return thisSignIndex.CompareTo(otherSignIndex);
    }

    public object Clone()
    {
        return new Sign(Id, Name, Surname, ZodiacSign, Birthdate);
    }
}