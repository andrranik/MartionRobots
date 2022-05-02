using MartionRobots.Models;

namespace MartionRobots.Core;

public class RobotDispatcher : IRobotDispatcher
{
    public Robot GetOrCreateRobot(RobotPosition position)
    {
        throw new System.NotImplementedException();
    }

    public void SendInstruction(Robot robot, string instruction)
    {
        throw new System.NotImplementedException();
    }
}