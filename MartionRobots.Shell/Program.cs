// See https://aka.ms/new-console-template for more information

using MartionRobots.Core;
using MartionRobots.Models;

var dispatcher = new RobotDispatcher();

var robot = new Robot(5,5, Direction.E, new Surface(new Coordinate(7, 7)));
robot.ApplyInstruction("FFFF");