using Moq;
using NUnit.Framework;
using RobotCleaner.Interface;
using RobotCleaner.Service;
using System;
using System.Collections.Generic;

namespace RobotCleaner.Test
{
    [TestFixture]
    public class CoreTest
    {
        private Robot _robot;
        private Position _position;
        private IList<Coordinate> _coordinates;
        public Mock<ICoordinateService> CoordinateServiceMock;

        [SetUp]
        public void Init()
        {
            CoordinateServiceMock = new Mock<ICoordinateService>();
            
            _position = new Position(0, 0);
            _coordinates = new List<Coordinate>();
            _robot = new Robot(_position, _coordinates);
        }

        #region Cint Test
        [Test]
        public void should_test_cint_solution()
        {
            _position = new Position(10, 22);
            _coordinates = new List<Coordinate> { new Coordinate("E 2"), new Coordinate("N 1") };
            _robot = new Robot(_position, _coordinates);
            var coordinateService = new CoordinateService();

            Program.Execute(_robot, coordinateService);

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

        #region Movement Test
        [Test]
        public void should_verify_execute_steps()
        {
            var coordinate = new Coordinate("E 2");
            _robot.Commands = new List<Coordinate> { coordinate };

            Program.Execute(_robot, CoordinateServiceMock.Object);

            CoordinateServiceMock.Verify(x => x.ExecuteSteps(It.IsAny<Robot>(), It.IsAny<Coordinate>()), Times.Once);
        }

        [Test]
        public void should_move_towards()
        {
            var coordinate = new Coordinate("E 2");
            _robot.Commands = new List<Coordinate> { coordinate };

            var coordinateService = new CoordinateService();
            coordinateService.ExecuteSteps(_robot, coordinate);

            var expected = new Position(2, 0);

            Assert.AreEqual(_robot.Position.PositionX, expected.PositionX);
            Assert.AreEqual(_robot.Position.PositionY, expected.PositionY);
        }

        [Test]
        public void should_raise_exception()
        {
            var coordinate = new Coordinate("X 2");
            _robot.Commands = new List<Coordinate> { coordinate };

            var coordinateService = new CoordinateService();

            Assert.Throws<ArgumentException>(() => coordinateService.ExecuteSteps(_robot, coordinate));
        }

        [Test]
        public void should_test_round_clean()
        {
            _coordinates = new List<Coordinate> { new Coordinate("E 1"), new Coordinate("N 1"), new Coordinate("W 1"), new Coordinate("S 1") };
            _robot = new Robot(_position, _coordinates);
            var coordinateService = new CoordinateService();

            Program.Execute(_robot, coordinateService);

            Assert.AreEqual(_robot.Report, "=> Cleaned: 4");
        }
        #endregion


    }
}
