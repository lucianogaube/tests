using RobotCleaner.Interface;
using System.Collections.Generic;
using static System.Console;

namespace RobotCleaner
{
    public static class Core
    {
        /// <summary>
        /// Initializes the starting positions and commands for the robot
        /// </summary>
        /// <returns>New Instance of the Robot with defined commands and position</returns>
        public static Robot Initialize()
        {
            var numberOfCommands = int.Parse(ReadLine() ?? "");
            var startingPostions = ReadLine()?.Split(' ');
            var startingPostion = new Position(0, 0);

            if (startingPostions != null)
            {
                startingPostion = new Position(int.Parse(startingPostions[0]), int.Parse(startingPostions[1]));
            }

            var directions = new List<ICoordinate>();

            for (var i = 0; i < numberOfCommands; i++)
            {
                var coordinates = ReadLine();
                directions.Add(new Coordinate(coordinates));
            }

            return new Robot(startingPostion, directions);
        }
    }
}
