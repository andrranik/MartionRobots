using Autofac;
using MartionRobots.Core;
using MartionRobots.Models;
using MartionRobots.Shell;


var containerBuilder = new ContainerBuilder();
Startup.ConfigureContainer(containerBuilder);
var container = containerBuilder.Build();

var surfaceFactory = container.Resolve<ISurfaceFactory>();
var dispatcher = container.Resolve<IRobotDispatcher>();

var initialText =
@"             Hello! 
It's the Martian Robot Coordinator!
First of all you need to input upper-right point of surface.";

Console.WriteLine(initialText);
Console.Write("Upper-right x -> ");
var x = int.Parse(Console.ReadLine());
Console.Write("Upper-right y -> ");
var y = int.Parse(Console.ReadLine());
var surface = surfaceFactory.CreateSurface(new Coordinate(x, y));
Console.WriteLine($"Surface from 0x0 to {x}x{y} has been created.");


while (true)
{
    Console.WriteLine("To take a manage of another robot press 'ENTER'. To quit pres 'ESCAPE'");
    if (Console.ReadKey().Key == ConsoleKey.Escape)
    {
        break;
    }
        
    Console.Write("Enter X -> ");
    var robotX = int.Parse(Console.ReadLine());
    Console.Write("Enter Y -> ");
    var robotY = int.Parse(Console.ReadLine());
    Console.Write("Direction  ('N', 'E', 'S', 'W') -> ");
    var direction = (Direction)int.Parse(Console.ReadLine());
    var robot = dispatcher.GetOrCreateRobot(new RobotPositionStruct(robotX, robotY, direction), surface);
    Console.Write("Write instruction -> ");
    var instruction = Console.ReadLine();
    Console.WriteLine(robot.ApplyInstruction(instruction));
}
