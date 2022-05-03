using System.Collections.Generic;
using MartionRobots.Models;

namespace MartionRobots.Core;

public class RobotDispatcher : IRobotDispatcher
{
    private readonly IRobotFactory _robotFactory;
    private Dictionary<RobotPositionStruct, IRobot> _robots;

    public RobotDispatcher(IRobotFactory robotFactory)
    {
        _robotFactory = robotFactory;
        _robots = new Dictionary<RobotPositionStruct, IRobot>();
    }

    public IRobot GetOrCreateRobot(RobotPositionStruct position, ISurface surface)
    {
        return _robots.TryGetValue(position, out var robot)
            ? robot
            : _robotFactory.CreateRobot(new RobotInfo(position.X, position.Y, position.Direction), surface);
    }
}