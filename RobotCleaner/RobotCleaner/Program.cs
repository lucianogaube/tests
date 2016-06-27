using static System.Console;

namespace RobotCleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var robot = Core.Initialize();

            foreach (var command in robot.Commands)
            {
                command.ExecuteSteps(robot);
            }

            WriteLine(robot.Report());
            ReadLine();
        }

    }
}
