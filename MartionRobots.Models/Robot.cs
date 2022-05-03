namespace MartionRobots.Models;

public interface IRobot
{
    RobotPositionStruct Position { get; }
    ISurface Surface { get; }
    string ApplyInstruction(string instructions);
}

public class Robot : IRobot
{
    public Robot(RobotPositionStruct position, ISurface surface)
    {
        Position = position;
        Surface = surface;
    }

    public Robot(int x, int y, Direction direction, ISurface surface)
    {
        Position = new RobotPositionStruct(x, y, direction);
        Surface = surface;
    }

    public RobotPositionStruct Position { get; private set; }
    public ISurface Surface { get; }

    public string ApplyInstruction(string instructions)
    {
        foreach (var instruction in instructions.ToUpper())
            switch (instruction)
            {
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'F':
                    MoveForward();
                    break;
                default: throw new ApplicationException("Wrong Instruction");
            }

        return Position.ToString();
    }

    private void TurnLeft()
    {
        Position = new RobotPositionStruct(Position.X, Position.Y, Position.Direction.Previous());
    }

    private void TurnRight()
    {
        Position = new RobotPositionStruct(Position.X, Position.Y, Position.Direction.Next());
    }

    private void MoveForward()
    {
        Position = Position.Direction switch
        {
            Direction.N => new RobotPositionStruct(Position.X, Position.Y + 1, Position.Direction),
            Direction.E => new RobotPositionStruct(Position.X + 1, Position.Y, Position.Direction),
            Direction.S => new RobotPositionStruct(Position.X, Position.Y - 1, Position.Direction),
            Direction.W => new RobotPositionStruct(Position.X - 1, Position.Y, Position.Direction),
            _ => throw new ArgumentOutOfRangeException("Wrong Direction!")
        };
    }
}