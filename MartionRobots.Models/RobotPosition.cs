namespace MartionRobots.Models;

public class RobotPosition : Coordinate
{
    public RobotPosition(int x, int y, Direction direction) : base(x, y)
    {
        Direction = direction;
    }
    public Direction Direction { get; set; }

    #region Overrides

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Direction);
    }

    public void AddX(int num) => X += num;
    public void AddY(int num) => Y += num;
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

    #endregion
}