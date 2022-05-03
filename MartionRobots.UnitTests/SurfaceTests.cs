using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using MartionRobots.Models;
using MartionRobots.Models.Exceptions;
using NUnit.Framework;

namespace MartionRobots.UnitTests;

public class SurfaceTests
{
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    [TestCaseSource(nameof(GetSurfaces))]
    public void TestCreateSurfaceSuccess(Coordinate coordinate)
    {
        var surface = new Surface(coordinate);
        Assert.AreEqual(0, surface.Start.X);
        Assert.AreEqual(0, surface.Start.Y);
        Assert.AreEqual(coordinate.X, surface.End.X);
        Assert.AreEqual(coordinate.Y, surface.End.Y);
    }

    [Test]
    public void TestCreateEmptySurface()
    {
        var exception = Assert.Throws<SurfaceCreationException>(() => new Surface(new Coordinate(0, 0)));
        Assert.AreEqual("It's impossible to create an empty surface.", exception?.Message);
    }

    [Test]
    [TestCase(51, 50)]
    [TestCase(50, 51)]
    [TestCase(51, 51)]
    [TestCase(100, 100)]
    public void TestCreateOutOfLimitSurface(int x, int y)
    {
        var exception = Assert.Throws<SurfaceCreationException>(() => new Surface(new Coordinate(x, y)));
        Assert.AreEqual("Max size of surface exceeded.", exception?.Message);
    }
    
    [Test]
    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    [TestCase(-1, -1)]
    [TestCase(-10, -10)]
    public void TestCreateNegativeCoordinateSurface(int x, int y)
    {
        var exception = Assert.Throws<SurfaceCreationException>(() => new Surface(new Coordinate(x, y)));
        Assert.AreEqual("One of coordinates has negative value.", exception?.Message);        
    }
    
    [Test]
    [TestCaseSource(nameof(GetAllowMoveIsTrueTestCases))]
    public void TestAllowMoveIsTrue(RobotPosition position)
    {
        var surface = new Surface(new Coordinate(10, 10)); 
        Assert.True(surface.AllowMove(position));
    }

    [Test]
    [TestCaseSource(nameof(GetLosses))]
    public void TestAllowMoveIsFalse(RobotPosition positions)
    {
        var surface = new Surface(new Coordinate(10, 10));
        var losses = GetLosses();
        surface.Losses.AddRange(losses);
        Assert.False(surface.AllowMove(positions));
    }

    [Test]
    [TestCase(10, 10, 10, 10, Direction.N)]
    [TestCase(10, 10, 0, 0, Direction.S)]
    [TestCase(10, 10, 10, 0, Direction.E)]
    [TestCase(10, 10, 0, 0, Direction.W)]
    public void TestAllowMoveThrows(int surfaceX, int surfaceY, int robotX, int robotY, Direction direction)
    {
        var surface = new Surface(new Coordinate(surfaceX, surfaceY));
        var robotPosition = new RobotPosition(robotX, robotY, direction);
        Assert.Throws<Exception>(() => surface.AllowMove(robotPosition));
    }

    public static IEnumerable<RobotPosition> GetAllowMoveIsTrueTestCases()
    {
        var surface = new Surface(new Coordinate(10, 10));
        for (int x = 0; x <= 10; x++)
        {
            for (int y = 0; y <= 10; y++)
            {
                for (int d = 0; d < 4; d++)
                {
                    if (x == 0 && d == (int)Direction.W || x == 10 && d == (int)Direction.E ||
                        y == 0 && d == (int)Direction.S || y == 10 && d == (int)Direction.N)
                        continue;

                    yield return new RobotPosition(x, y, (Direction)d);
                }
            }
        }
    }

    public static IEnumerable<Coordinate> GetSurfaces()
    {
        for (var x = 1; x <= 50; x++)
        {
            for (var y = 1; y < 50; y++)
            {
                yield return new Coordinate(x, y);
            }
        }
    }

    public static List<RobotPosition> GetLosses()
    {
        return Enumerable.Range(0, 10)
            .Select(x => new RobotPosition(x, 0, Direction.S))
            .Concat(Enumerable.Range(0, 11).Select(x => new RobotPosition(x, 10, Direction.N)))
            .Concat(Enumerable.Range(0, 11).Select(x => new RobotPosition(0, x, Direction.W)).ToList())
            .Concat(Enumerable.Range(0, 11).Select(x => new RobotPosition(10, x, Direction.E)).ToList())
            .ToList();
    }
}