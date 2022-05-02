namespace MartionRobots.Models;

public class Robot
{
    public Robot(RobotPosition position, ISurface surface)
    {
        Position = position;
        Surface = surface;
    }

    public Robot(int x, int y, Direction direction, ISurface surface)
    {
        Position = new RobotPosition(x, y, direction);
        Surface = surface;
    }

    public RobotPosition Position { get; }
    public ISurface Surface { get; }
    public Direction Direction
    {
        get => Position.Direction;
        set => Position.Direction = value;
    }

    public void ApplyInstruction(string instructions)
    {
        foreach (var instruction in instructions.ToUpper())
        {
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
        }
    }

    private void TurnLeft() => Direction = Direction.Previous();

    private void TurnRight() => Direction = Direction.Next();

    private void MoveForward()
    {
        switch (Direction)
        {
            case Direction.N:
                Position.AddY(1);
                break;
            case Direction.E:
                Position.AddX(1);
                break;
            case Direction.S:
                Position.AddY(-1);
                break;
            case Direction.W:
                Position.AddX(-1);
                break;
            default:
                throw new ArgumentOutOfRangeException("Wrong Direction!");
        }

        if (!Surface.Includes(Position))
            throw new Exception("LOST");
    }
}