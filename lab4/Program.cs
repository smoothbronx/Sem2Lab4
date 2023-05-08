using lab4;

Main();

void Main()
{
    var signs = GetSigns(8);
    foreach (var sign in signs)
    {
        Console.WriteLine($"ObjectID: {sign.Id}, name: {sign.Name}, " +
                          $"surname: {sign.Surname}, sign: {sign.ZodiacSign}," +
                          $" birthdate: [{string.Join('.', sign.Birthdate)}]");
    }
    Console.WriteLine();
    
    Array.Sort(signs, new SignComparator());
    DisplaySigns(signs);
    Console.WriteLine();
    
    SelectSigns(signs);
}

void SelectSigns(Sign[] signs)
{
    var selectedMonth = GetIntegerFromConsole("Enter month number: ");
    if (selectedMonth is < 1 or > 12) throw new Exception("Month cannot be such a entered value");
    var selectedSigns = signs.Where(sign => sign.Birthdate[1] == selectedMonth).ToArray();
    
    if (selectedSigns.Any())
    {
        DisplaySigns(selectedSigns.ToArray());
        return;
    }
    
    Console.WriteLine("Signs with selected month not exists");
}

void DisplaySigns(Sign[] signs)
{
    foreach (var sign in signs)
    {
        Console.WriteLine($"ObjectID: {sign.Id}, name: {sign.Name}, " +
                          $"surname: {sign.Surname}, sign: {sign.ZodiacSign}," +
                          $" birthdate: [{string.Join('.', sign.Birthdate)}]");
    }
}


Sign[] GetSigns(int signsNumber)
{
    var result = new Sign[signsNumber];
    for (var index = 0; index < signsNumber; index++)
    {
        var name = GetStringFromConsole("Enter your name: ");
        var surname = GetStringFromConsole("Enter your surname: ");
        var zodiacSign = GetStringFromConsole("Enter your zodiac sign: ");
        var birthday = GetBirthdayFromConsole("Enter your birthday as DD.MM.YYYY: ");

        result[index] = new Sign(index, name, surname, zodiacSign, birthday);
        Console.WriteLine();
    }

    Array.Sort(result);
    return result.ToArray();
}

int GetIntegerFromConsole(string message)
{
    while (true)
    {
        var stringNumber = GetStringFromConsole(message);

        if (int.TryParse(stringNumber, out var parsed)) return parsed;
    }
}

int[] GetBirthdayFromConsole(string message)
{
    while (true)
    {
        var stringBirthday = GetStringFromConsole(message);
        var birthdayStringSegments = stringBirthday.Split('.');
        if (birthdayStringSegments.Length != 3) continue;
        var birthdayDate = Array.ConvertAll(birthdayStringSegments, int.Parse);
        if (!IsValidDate(birthdayDate[0], birthdayDate[1], birthdayDate[2])) continue;
        return birthdayDate;
    }
}

bool IsValidDate(int day, int month, int year)
{
    var currentDate = DateTime.Now.Year;
    if (day is < 1 or > 31) return false;
    if (month is < 1 or > 12) return false;
    if (year < currentDate - 120 || year > currentDate) return false;
    return true;
}

string GetStringFromConsole(string message)
{
    while (true)
    {
        Console.Write(message);
        var stringVar = Console.ReadLine();

        if (stringVar == null) continue;
        if (stringVar.Length == 0) continue;

        return stringVar;
    }
}