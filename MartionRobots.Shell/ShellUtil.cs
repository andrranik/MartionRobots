using MartionRobots.Models;

namespace MartionRobots.Shell;

public class ShellUtil
{
    public static int SaveReadInt(string message)
    {
        int num;
        do Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out num));
        return num;
    }

    public static Direction ReadDirections(string message)
    {
        string? str = null;
        do
        {
            Console.Write(message);
            str = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(str) || str.Length != 1);
        return (Direction)Enum.Parse(typeof(Direction), str);
    }
}