using MartionRobots.Models.Exceptions;
using MartionRobots.Models.Interfaces;

namespace MartionRobots.Models;

public class Robot : IRobot
{
    public Robot(RobotPosition position, ISurface surface)
    {
        Surface = surface ?? throw new ArgumentNullException(nameof(surface));
        
        if (position.X > surface.End.X || position.Y > surface.End.Y)
            throw new RobotCreationException("Max size of surface exceeded.");
        
        if (position.X < surface.Start.X || position.Y < surface.Start.Y)
            throw new RobotCreationException("One of coordinates has negative value.");
        
        Position = position;
        
    }

    public Robot(int x, int y, Direction direction, ISurface surface)
    {
        Position = new RobotPosition(x, y, direction);
        Surface = surface;
    }

    public RobotPosition Position { get; private set; }
    public ISurface Surface { get; }

    public string ApplyInstruction(string instructions)
    {
        try
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
                    default: throw new RobotWrongInstructionException("Wrong Instruction");
                }

        }
        catch (RobotLostException)
        {
            return $"{Position.X} {Position.Y} LOST";
        }
        
        return Position.ToString();
    }

    private void TurnLeft()
    {
        Position = new RobotPosition(Position.X, Position.Y, Position.Direction.Previous());
    }

    private void TurnRight()
    {
        Position = new RobotPosition(Position.X, Position.Y, Position.Direction.Next());
    }

    private void MoveForward()
    {
        if (Surface.AllowMove(Position))
        {
            Position = Position.Direction switch
            {
                Direction.N => new RobotPosition(Position.X, Position.Y + 1, Position.Direction),
                Direction.E => new RobotPosition(Position.X + 1, Position.Y, Position.Direction),
                Direction.S => new RobotPosition(Position.X, Position.Y - 1, Position.Direction),
                Direction.W => new RobotPosition(Position.X - 1, Position.Y, Position.Direction),
                _ => throw new ArgumentOutOfRangeException("Unsupported direction.")
            };
        }
    }
}