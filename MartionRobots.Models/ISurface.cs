namespace MartionRobots.Models;

public interface ISurface
{
    bool Includes(Coordinate coordinate);
}