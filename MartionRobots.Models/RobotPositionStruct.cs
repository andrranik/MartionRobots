namespace MartionRobots.Models;

public readonly struct RobotPosition
{
    public RobotPosition(int x, int y, Direction direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }
    public int X { get; }
    public int Y { get; }
    public Direction Direction { get; }

    public override bool Equals(object? obj)
    {
        if (obj is RobotPosition rp)
        {
            return rp.X == X &&
                   rp.Y == Y &&
                   rp.Direction == Direction;
        }

        return false;
    }

    public bool Equals(RobotPosition other)
    {
        return X == other.X && Y == other.Y && Direction == other.Direction;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, (int)Direction);
    }

    public override string ToString()
    {
        return $"{X} {Y} {Enum.GetName(typeof(Direction), Direction)}";
    }

}