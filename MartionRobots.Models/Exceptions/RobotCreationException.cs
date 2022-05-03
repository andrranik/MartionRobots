namespace MartionRobots.Models.Exceptions;

public class RobotCreationException : Exception
{
    public RobotCreationException(string message) : base(message)
    {
    }
}