namespace MartionRobots.Models.Exceptions;

public class RobotWrongInstructionException : Exception
{
    public RobotWrongInstructionException(string message) : base(message)
    {
    }
}