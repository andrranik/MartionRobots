namespace MartionRobots.Models.Interfaces;

public interface IRobot
{
    RobotPosition Position { get; }
    ISurface Surface { get; }
    string ApplyInstruction(string instructions);
}