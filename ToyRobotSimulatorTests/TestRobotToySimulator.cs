using NUnit.Framework;
using System;
using ToyRobotSimulator;

namespace ToyRobotSimulatorTests
{
    [TestFixture()]
    public class TestRobotToySimulator
    {
        [Test()]
        public void Should_Throw_Exception_When_Robot_Not_Placed()
        {
            // Arrange
            Robot testRobot = new Robot();

            // Act
            var ex = Assert.Throws<Exception>(() => MainClass.ExecuteMovement());

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Toy Robot was not placed for movement"));
        }
        [Test()]
        public void Should_Throw_Exception_When_Place_Coordinates_Are_Invalid()
        {
            // Arrange
            Robot testRobot = new Robot();

            // Act
            var ex = Assert.Throws<Exception>(() => MainClass.PlacementCommand("PLACE 6,8,SOUTH", testRobot));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Coordinates supplied in a 'PLACE' command are invalid"));

        }
        [Test()]
        public void Should_Ignore_Move_When_Step_Causes_Fall()
        {
            // Arrange
            Robot testRobot = new Robot();
            testRobot.xCoordinate = 0;
            testRobot.yCoordinate = 0;
            testRobot.facing = "NORTH";
            var expected = "0,0,WEST";

            // Act
            MainClass.LeftCommand(testRobot.facing, testRobot);
            MainClass.MoveCommand(testRobot.facing, testRobot);
            var actual = MainClass.ReportCommand(testRobot);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [Test()]
        public void Should_Turn_Left_On_Left_Command()
        {
            // Arrange
            Robot testRobot = new Robot();
            testRobot.xCoordinate = 0;
            testRobot.yCoordinate = 0;
            testRobot.facing = "SOUTH";
            var expected = "0,0,EAST";

            // Act
            MainClass.LeftCommand(testRobot.facing, testRobot);
            var actual = MainClass.ReportCommand(testRobot);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [Test()]
        public void Should_Turn_Right_On_Right_Command()
        {
            // Arrange
            Robot testRobot = new Robot();
            testRobot.xCoordinate = 0;
            testRobot.yCoordinate = 0;
            testRobot.facing = "SOUTH";
            var expected = "0,0,WEST";

            // Act
            MainClass.RightCommand(testRobot.facing, testRobot);
            var actual = MainClass.ReportCommand(testRobot);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [Test()]
        public void Should_Step_Forward_On_Move_Command()
        {
            // Arrange
            Robot testRobot = new Robot();
            testRobot.xCoordinate = 1;
            testRobot.yCoordinate = 1;
            testRobot.facing = "NORTH";
            var expected = "1,2,NORTH";

            // Act
            MainClass.MoveCommand(testRobot.facing, testRobot);
            var actual = MainClass.ReportCommand(testRobot);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [Test()]
        public void Should_Return_Position_On_Report_Command()
        {
            // Arrange
            Robot testRobot = new Robot();
            testRobot.xCoordinate = 1;
            testRobot.yCoordinate = 1;
            testRobot.facing = "WEST";
            var expected = "1,1,WEST";

            // Act
            var actual = MainClass.ReportCommand(testRobot);

            // Assert
            Assert.AreEqual(expected, actual);

        }

    }
}
