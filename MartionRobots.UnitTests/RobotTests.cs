using System.Collections.Generic;
using MartionRobots.Models;
using MartionRobots.Models.Exceptions;
using MartionRobots.Models.Interfaces;
using Moq;
using NUnit.Framework;

namespace MartionRobots.UnitTests;

public class RobotTests
{

    private ISurface _surfaceMock;
    [SetUp]
    public void Setup()
    {
        var surfaceMock = new Mock<ISurface>();
        surfaceMock.Setup(x => x.End)
            .Returns(new Coordinate(10, 10));
        surfaceMock.Setup(x => x.Start)
            .Returns(new Coordinate(0, 0));
        surfaceMock.Setup(x => x.AllowMove(It.IsAny<RobotPosition>()))
            .Returns(true);
        _surfaceMock = surfaceMock.Object;
    }
    
    [Test]
    [TestCaseSource(nameof(GetPositions))]
    public void TestCreationRobotSuccess(RobotPosition position)
    {
        var robot = new Robot(position, _surfaceMock);
        Assert.AreEqual(position.X, robot.Position.X);
        Assert.AreEqual(position.Y, robot.Position.Y);
        Assert.AreEqual(position.Direction, robot.Position.Direction);
    }

    
    [Test]
    [TestCase(-1, -1, Direction.N)]
    [TestCase(-1, 0, Direction.N)]
    [TestCase(0, -1, Direction.N)]
    public void TestCreationRobotNegativePosition(int x, int y, Direction direction)
    {
        var ex = Assert.Throws<RobotCreationException>(() => new Robot(new RobotPosition(x, y, direction), _surfaceMock));
        Assert.AreEqual("One of coordinates has negative value.", ex?.Message);
    }
    
    [Test]
    [TestCase(11, 11, Direction.N)]
    [TestCase(10, 11, Direction.N)]
    [TestCase(11, 10, Direction.N)]
    public void TestCreationRobotOutOfRange(int x, int y, Direction direction)
    {
        var ex = Assert.Throws<RobotCreationException>(() => new Robot(new RobotPosition(x, y, direction), _surfaceMock));
        Assert.AreEqual("Max size of surface exceeded.", ex?.Message);
    }
    
    [Test]
    [TestCase(0, 0, Direction.N, "FFFFF", 0, 5, Direction.N)]
    [TestCase(0, 0, Direction.N, "RFFFFF", 5, 0, Direction.E)]
    [TestCase(10, 10, Direction.S, "FFFFF", 10, 5, Direction.S)]
    public void TestApplyInstruction(int x, int y, Direction direction, string instruction, int expX, int expY, Direction expD)
    {
        var robot = new Robot(new RobotPosition(x, y, direction), _surfaceMock);
        robot.ApplyInstruction(instruction);
        Assert.AreEqual(expX, robot.Position.X);
        Assert.AreEqual(expY, robot.Position.Y);
        Assert.AreEqual(expD, robot.Position.Direction);
    }

    public static IEnumerable<RobotPosition> GetPositions()
    {
        for (int x = 0; x <= 10; x++)
        {
            for (int y = 0; y <= 10; y++)
            {
                for (int i = 0; i < 4; i++)
                {
                    yield return new RobotPosition(x, y, (Direction)i);
                }
            }
        }
    }
}