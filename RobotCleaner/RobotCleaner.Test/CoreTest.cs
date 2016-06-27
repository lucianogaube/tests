using Moq;
using NUnit.Framework;
using RobotCleaner.Interface;
using System.Collections.Generic;

namespace RobotCleaner.Test
{
    [TestFixture]
    public class CoreTest
    {
        private Robot _robot;
        private Position _position;
        private IList<ICoordinate> _coordinates;
        private Mock<ICoordinate> _coordinateMock;

        [SetUp]
        public void Init()
        {
            _coordinateMock = new Mock<ICoordinate>();
            
            _position = new Position(0, 0);
            _coordinates = new List<ICoordinate>();
            _robot = new Robot(_position, _coordinates);
        }

        #region Cint Test
        [Test]
        public void should_test_cint_solution()
        {
            _position = new Position(10, 22);
            _coordinates = new List<ICoordinate> { new Coordinate("E 2"), new Coordinate("N 1") };
            _robot = new Robot(_position, _coordinates);

            Program.Execute(_robot);

            Assert.AreEqual(_robot.Report, "=> Cleaned: 4");
        } 
        #endregion
        
        #region Clean Test
        [Test]
        public void should_clean_dirty_room()
        {
            _robot.Position = new Position(10, 22);
            _robot.Clean();

            Assert.AreEqual(_robot.CleanedSpots.Count, 2);
        }

        [Test]
        public void should_not_clean_again()
        {
            _robot.Position = new Position(0, 0);
            _robot.Clean();

            Assert.AreEqual(_robot.CleanedSpots.Count, 1);
        }
        #endregion

        [Test]
        public void should_move_east_north()
        {
            _robot.Commands = new List<ICoordinate> { new Coordinate("E 2") };
            _coordinateMock.Object.ExecuteSteps(_robot);

            _coordinateMock.Setup(x => x.MoveAndClean(It.IsAny<Robot>(), It.IsAny<Cardinals>()));
            _coordinateMock.Verify(x => x.MoveAndClean(It.IsAny<Robot>(), It.IsAny<Cardinals>()), Times.Exactly(2));

            //Assert.AreEqual(_robot.Position.PositionX, 2);
            //Assert.AreEqual(_robot.Position.PositionY, 1);
        }
    }
}
