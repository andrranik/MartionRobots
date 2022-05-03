using MartionRobots.Models;
using MartionRobots.Models.Interfaces;

namespace MartionRobots.Core;

public interface IRobotDispatcher
{
    IRobot GetOrCreateRobot(RobotPosition position, ISurface surface);
}