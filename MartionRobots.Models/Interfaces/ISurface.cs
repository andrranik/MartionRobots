namespace MartionRobots.Models.Interfaces;

public interface ISurface
{
    bool AllowMove(RobotPosition position);
    Coordinate Start { get; }
    Coordinate End { get; }
}