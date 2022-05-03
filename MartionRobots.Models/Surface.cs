using System.Data;
using System.Runtime.ExceptionServices;
using System.Transactions;

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
    public List<RobotPositionStruct> Losses { get; } = new List<RobotPositionStruct>();

    public void AddLoss(RobotPositionStruct coordinate)
    {
        Losses.Add(coordinate);
    }

    public bool Includes(Coordinate coordinate)
    {
        return coordinate <= End;
    }

    public bool AllowMove(RobotPositionStruct position)
    {
        if (Losses.Contains(position))
        {
            return false;
        }

        if (position.Direction == Direction.N)
        {
            if (position.Y == End.Y)
            {
                throw new Exception();
            }
        }

        if (position.Direction == Direction.S)
        {
            if (position.Y == Start.Y)
            {
                throw new Exception();
            }
        }

        if (position.Direction == Direction.E)
        {
            if (position.X == End.X)
            {
                throw new Exception();
            }
        }

        if (position.Direction == Direction.W)
        {
            if (position.X == Start.X)
            {
                throw new Exception();
            }
        }

        return true;
    }
}

public class SurfaceCreationException : Exception
{
    public SurfaceCreationException(string message) : base(message)
    {
    }
}