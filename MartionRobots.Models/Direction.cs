namespace MartionRobots.Models;

public enum Direction
{
    N = 0, E = 1, S = 2, W = 3
}

public static class DirectionExtensions
{
    public static Direction Next(this Direction src)
    {
        var arr = GetDirectionsArray();
        var j = Array.IndexOf(arr, src) + 1;
        return arr.Length == j ? arr[0] : arr[j];
    }

    public static Direction Previous(this Direction src)
    {
        var arr = GetDirectionsArray();
        var j = Array.IndexOf(arr, src) - 1;
        return j == -1 ? arr[^1] : arr[j];
    }

    private static Direction[] GetDirectionsArray()
    {
        return (Direction[])Enum.GetValues(typeof(Direction));
    }
}