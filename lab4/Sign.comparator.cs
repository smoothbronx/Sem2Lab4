namespace lab4;

internal class SignComparator : IComparer<Sign>
{
    public int Compare(Sign? x, Sign? y)
    {
        if (x == null || y == null)
            throw new ArgumentException("Any of objects is not a Sign");

        var xDate = new DateOnly(x.Birthdate[2], x.Birthdate[1], x.Birthdate[0]);
        var yDate = new DateOnly(y.Birthdate[2], y.Birthdate[1], y.Birthdate[0]);

        return xDate.CompareTo(yDate);
    }
}