namespace MartionRobots.Models;

public readonly struct RobotInfo
{
    public RobotInfo(int x, int y, Direction direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }

    public int X { get; }
    public int Y { get; }
    public Direction Direction { get; }
    
}