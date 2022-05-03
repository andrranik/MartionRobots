namespace MartionRobots.Models;

public struct Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Coordinate item) return item.X == X && item.Y == Y;

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    #region Operator Overloading

    public static bool operator >=(Coordinate c1, Coordinate c2)
    {
        return c1.X >= c2.X &&
               c1.Y >= c2.Y;
    }

    public static bool operator <=(Coordinate c1, Coordinate c2)
    {
        return c1.X <= c2.X &&
               c1.Y <= c2.Y;
    }

    public static bool operator >(Coordinate c1, Coordinate c2)
    {
        return c1.X > c2.X &&
               c1.Y > c2.Y;
    }

    public static bool operator <(Coordinate c1, Coordinate c2)
    {
        return c1.X < c2.X &&
               c1.Y < c2.Y;
    }

    public static bool operator ==(Coordinate left, Coordinate right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Coordinate left, Coordinate right)
    {
        return !(left == right);
    }

    #endregion
}