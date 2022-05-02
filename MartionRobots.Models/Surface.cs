namespace MartionRobots.Models;

public class Surface : ISurface
{
    public Surface(Coordinate end)
    {
        Start = new Coordinate(0,0);
        End = end;
    }

    public Coordinate Start { get; }
    public Coordinate End { get; }

    public bool Includes(Coordinate coordinate)
    {
        return coordinate <= End;
    }
}