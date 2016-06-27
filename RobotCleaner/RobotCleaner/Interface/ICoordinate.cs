namespace RobotCleaner.Interface
{
    public interface ICoordinate
    {
        /// <summary>
        /// Sets the numbers of times the movements should be done
        /// </summary>
        /// <param name="robot">Robot instance</param>
        void ExecuteSteps(Robot robot);

        /// <summary>
        /// Execute the movement and clean the dirty spot
        /// </summary>
        /// <param name="robot">Robot Instance</param>
        /// <param name="direction">Cardinal direction</param>
        void MoveAndClean(Robot robot, Cardinals direction);
    }
}