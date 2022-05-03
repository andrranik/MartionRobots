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
var x = ShellUtil.SaveReadInt("Upper-right x -> ");
var y = ShellUtil.SaveReadInt("Upper-right y -> ");
var surface = surfaceFactory.CreateSurface(new Coordinate(x, y));
Console.WriteLine($"Surface from 0x0 to {x}x{y} has been created.");

Console.WriteLine("To take a manage of another robot press 'ENTER'. To quit pres 'ESCAPE'");
while (Console.ReadKey().Key != ConsoleKey.Escape)
{
    var robotX = ShellUtil.SaveReadInt("Enter X -> ");
    var robotY = ShellUtil.SaveReadInt("Enter Y -> ");
    var direction = ShellUtil.ReadDirections("Direction  ('N', 'E', 'S', 'W') -> ");
    var robot = dispatcher.GetOrCreateRobot(new RobotPosition(robotX, robotY, direction), surface);
    Console.Write("Write instruction -> ");
    var instruction = Console.ReadLine();

    if (instruction != null)
        Console.WriteLine(robot.ApplyInstruction(instruction));
}
