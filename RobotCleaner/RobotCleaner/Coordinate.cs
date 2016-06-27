using RobotCleaner.Interface;
using System;
using static RobotCleaner.Cardinals;

namespace RobotCleaner
{
    /// <summary>
    /// Coordinate class, controls the movements 
    /// </summary>
    public class Coordinate : ICoordinate
    {
        public int Steps { get; set; }
        public Cardinals Direction { get; set; }

        /// <summary>
        /// Constructor with input by ReadLine
        /// </summary>
        /// <param name="input">String from ReadLine</param>
        public Coordinate(string input)
        {
            var inputs = input.Split(' ');

            Steps = int.Parse(inputs[1]);
            Direction = (Cardinals)char.Parse(inputs[0]);
        }

        /// <summary>
        /// Sets the numbers of times the movements should be done
        /// </summary>
        /// <param name="robot">Robot instance</param>
        public void ExecuteSteps(Robot robot)
        {
            for(var i = 0; i < Steps; i++)
            {
                MoveAndClean(robot, Direction);
            }
        }

        /// <summary>
        /// Execute the movement and clean the dirty spot
        /// </summary>
        /// <param name="robot">Robot Instance</param>
        /// <param name="direction">Cardinal direction</param>
        public void MoveAndClean(Robot robot, Cardinals direction)
        {
            switch (direction)
            {
                case North:
                    robot.Position = new Position(robot.Position.PositionX, robot.Position.PositionY + 1);
                    robot.Clean();
                    break;
                case East:
                    robot.Position = new Position(robot.Position.PositionX + 1, robot.Position.PositionY);
                    robot.Clean();
                    break;
                case West:
                    robot.Position = new Position(robot.Position.PositionX - 1, robot.Position.PositionY);
                    robot.Clean();
                    break;
                case South:
                    robot.Position = new Position(robot.Position.PositionX, robot.Position.PositionY - 1);
                    robot.Clean();
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }

    public enum Cardinals
    {
        North = 'N',
        South = 'S',
        West = 'W',
        East = 'E'
    }
}
