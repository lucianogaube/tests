using RobotCleaner.Interface;
using System;
using static RobotCleaner.Cardinals;

namespace RobotCleaner.Service
{
    public class CoordinateService : ICoordinateService
    {
        /// <summary>
        /// Sets the numbers of times the movements should be done
        /// </summary>
        /// <param name="robot">Robot instance</param>
        /// <param name="coordinate">Coordinate with steps and direction</param>
        public void ExecuteSteps(Robot robot, Coordinate coordinate)
        {
            for (var i = 0; i < coordinate.Steps; i++)
            {
                MoveAndClean(robot, coordinate.Direction);
            }
        }

        /// <summary>
        /// Execute the movement and clean the dirty spot
        /// </summary>
        /// <param name="robot">Robot Instance</param>
        /// <param name="direction">Cardinal direction</param>
        public virtual void MoveAndClean(Robot robot, Cardinals direction)
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
}
