using static System.Console;

namespace RobotCleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var robot = Core.Initialize();

            Execute(robot);

            WriteLine(robot.Report);
            ReadLine();
        }

        public static void Execute(Robot robot)
        {
            foreach (var command in robot.Commands)
            {
                command.ExecuteSteps(robot);
            }
        }

    }
}
