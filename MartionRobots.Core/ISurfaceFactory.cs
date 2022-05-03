using MartionRobots.Models;
using MartionRobots.Models.Interfaces;

namespace MartionRobots.Core;

public interface ISurfaceFactory
{
    ISurface CreateSurface(Coordinate coordinate);
}

public class DefaultSurfaceFactory : ISurfaceFactory
{
    public ISurface CreateSurface(Coordinate coordinate)
    {
        return new Surface(coordinate);
    }
}

