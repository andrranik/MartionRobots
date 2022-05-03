using MartionRobots.Models;
using MartionRobots.Models.Interfaces;

namespace MartionRobots.Core;

public interface IRobotFactory
{
    IRobot CreateRobot(RobotInfo info, ISurface surface);
}

public class DefaultRobotFactory : IRobotFactory
{
    
    public IRobot CreateRobot(RobotInfo info , ISurface surface)
    {
        return new Robot(info.X, info.Y, info.Direction, surface);
    }
}