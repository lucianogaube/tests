namespace RobotCleaner.Interface
{
    public interface ICoordinateService
    {
        /// <summary>
        /// Sets the numbers of times the movements should be done
        /// </summary>
        /// <param name="robot">Robot instance</param>
        /// <param name="coordinate">Coordinate with steps and direction</param>
        void ExecuteSteps(Robot robot, Coordinate coordinate);

        /// <summary>
        /// Execute the movement and clean the dirty spot
        /// </summary>
        /// <param name="robot">Robot Instance</param>
        /// <param name="direction">Cardinal direction</param>
        void MoveAndClean(Robot robot, Cardinals direction);
    }
}