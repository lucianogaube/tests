using RobotCleaner.Interface;
using System.Collections.Generic;

namespace RobotCleaner
{
    /// <summary>
    /// Robot class
    /// </summary>
    public class Robot
    {
        public Position Position { get; set; }
        public IList<ICoordinate> Commands { get; set; }
        public IList<Position> CleanedSpots;

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="initialPosition">Initial Position</param>
        /// <param name="commands">Commands with steps and directions</param>
        public Robot(Position initialPosition, IList<ICoordinate> commands)
        {
            Position = initialPosition;
            Commands = commands;
            CleanedSpots = new List<Position>();
            Clean();
        }

        /// <summary>
        /// Clean a spot that was not yet cleaned
        /// </summary>
        public void Clean()
        {
            if (!CleanedSpots.Contains(Position))
            {
                CleanedSpots.Add(Position);
            }
        }

        /// <summary>
        /// Returns the report of the robot's duty
        /// </summary>
        /// <returns>The report containing the number of cleaned spots</returns>
        public string Report()
        {
            return $"=> Cleaned: {CleanedSpots.Count}";
        }
    }
}
