using MartionRobots.Models;

namespace MartionRobots.Core;

public interface IRobotDispatcher
{
    Robot GetOrCreateRobot(RobotPosition position);
    void SendInstruction(Robot robot, string instruction);
}