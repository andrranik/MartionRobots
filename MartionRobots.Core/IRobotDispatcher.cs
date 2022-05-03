using MartionRobots.Models;

namespace MartionRobots.Core;

public interface IRobotDispatcher
{
    IRobot GetOrCreateRobot(RobotPositionStruct position, ISurface surface);
}