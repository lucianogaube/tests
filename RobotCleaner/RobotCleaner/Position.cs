namespace RobotCleaner
{
    public class Position
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        /// <summary>
        /// Constructor with x and y parameters
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="y">Y Coordinate</param>
        public Position(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }
    }
}
