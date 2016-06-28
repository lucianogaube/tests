using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner
{
    /// <summary>
    /// Robot class
    /// </summary>
    public class Robot
    {
        public Position Position { get; set; }
        public IList<Coordinate> Commands { get; set; }
        public IList<Position> CleanedSpots;

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="initialPosition">Initial Position</param>
        /// <param name="commands">Commands with steps and directions</param>
        public Robot(Position initialPosition, IList<Coordinate> commands)
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
            if (!CleanedSpots.Any(cs => cs.PositionX == Position.PositionX 
                                     && cs.PositionY == Position.PositionY))
            {
                CleanedSpots.Add(Position);
            }
        }

        /// <summary>
        /// Returns the report of the robot's duty
        /// </summary>
        /// <value>The report containing the number of cleaned spots</value>
        public string Report => $"=> Cleaned: {CleanedSpots.Count}";
    }
}
