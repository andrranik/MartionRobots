using MartionRobots.Models.Exceptions;
using MartionRobots.Models.Interfaces;

namespace MartionRobots.Models;

public class Surface : ISurface
{
    public Surface(Coordinate end)
    {
        if (end.X > 50 || end.Y > 50)
            throw new SurfaceCreationException("Max size of surface exceeded.");

        if (end.X == 0 || end.Y == 0)
            throw new SurfaceCreationException("It's impossible to create an empty surface.");
        
        if (end.X < 0 || end.Y < 0)
            throw new SurfaceCreationException("One of coordinates has negative value.");
        
        Start = new Coordinate(0,0);
        End = end;
    }

    public Coordinate Start { get; }
    public Coordinate End { get; }
    public List<RobotPosition> Losses { get; } = new List<RobotPosition>();

    public void AddLoss(RobotPosition coordinate)
    {
        Losses.Add(coordinate);
    }
    public bool AllowMove(RobotPosition position)
    {
        if (Losses.Contains(position))
        {
            return false;
        }

        Func<bool> condition = position.Direction switch
        {
            Direction.N => () => position.Y == End.Y,
            Direction.E => () => position.X == End.X,
            Direction.S => () => position.Y == Start.Y,
            Direction.W => () => position.X == Start.X,
            _ => throw new ArgumentOutOfRangeException()
        };

        if (condition())
            throw new RobotLostException();

        return true;
    }
}