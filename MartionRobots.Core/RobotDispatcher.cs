using System.Collections.Generic;
using MartionRobots.Models;
using MartionRobots.Models.Interfaces;

namespace MartionRobots.Core;

public class RobotDispatcher : IRobotDispatcher
{
    private readonly IRobotFactory _robotFactory;
    private Dictionary<RobotPosition, IRobot> _robots;

    public RobotDispatcher(IRobotFactory robotFactory)
    {
        _robotFactory = robotFactory;
        _robots = new Dictionary<RobotPosition, IRobot>();
    }

    public IRobot GetOrCreateRobot(RobotPosition position, ISurface surface)
    {
        return _robots.TryGetValue(position, out var robot)
            ? robot
            : _robotFactory.CreateRobot(new RobotInfo(position.X, position.Y, position.Direction), surface);
    }
}