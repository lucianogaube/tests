using RobotCleaner.Interface;
using RobotCleaner.Service;
using static System.Console;

namespace RobotCleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var robot = Core.Initialize();
            ICoordinateService coordinateService = new CoordinateService();

            Execute(robot, coordinateService);

            WriteLine(robot.Report);
            ReadLine();
        }

        public static void Execute(Robot robot, ICoordinateService coordinateService)
        {
            foreach (var command in robot.Commands)
            {
                coordinateService.ExecuteSteps(robot, command);
            }
        }
    }
}
