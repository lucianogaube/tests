namespace RobotCleaner
{
    /// <summary>
    /// Coordinate class, controls the movements 
    /// </summary>
    public class Coordinate
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
    }

    public enum Cardinals
    {
        North = 'N',
        South = 'S',
        West = 'W',
        East = 'E'
    }
}
