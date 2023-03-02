using Lift;

namespace LiftTests
{
    public class LiftTests
    {
        [Test]
        public void FitPeopleOnTheLiftWithValidInput()
        {
            // Arrange
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 4, 4, 4 };
            int waitingPeopleCount = 5;
            int[] expectedLiftState = { 4, 4, 4 };
            // Act
            int[] actualLiftState = liftSimulator.FitPeopleOnTheLift(waitingPeopleCount, inputLiftState);
            // Assert
            Assert.That(expectedLiftState, Is.EqualTo(actualLiftState));
        }
        [Test]
        public void FitPeopleOnTheLiftWithInvalidPeopleCount()
        {
            // Arrange
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 4, 4, 4 };
            int waitingPeopleCount = -1;
            // Assert
            Assert.Throws<ArgumentException>(() => liftSimulator.FitPeopleOnTheLift(waitingPeopleCount, inputLiftState));
        }
        [Test]
        public void FitPeopleOnTheLiftWithInvalidLiftSize()
        {
            // Arrange
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { -1, -4, -4 };
            int waitingPeopleCount = 5;
            // Assert
            Assert.Throws<ArgumentException>(() => liftSimulator.FitPeopleOnTheLift(waitingPeopleCount, inputLiftState));
        }
        [Test]
        public void FitPeopleOnTheLiftWithInvalidLiftState()
        {
            // Arrange
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = null;
            int waitingPeopleCount = 5;
            // Assert
            Assert.Throws<ArgumentException>(() => liftSimulator.FitPeopleOnTheLift(waitingPeopleCount, inputLiftState));
        }
        [Test]
        public void FitPeopleOnTheLiftAndGetResultWithNotEnoughSpace()
        {
            // Arrange
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 3, 2, 4 };
            int waitingPeopleCount = 6;
            string expectedMsg = "There isn't enough space! 3 people in a queue!\r\n4 4 4";
            // Act
            string actualMsg = liftSimulator.FitPeopleOnTheLiftAndGetResult(waitingPeopleCount, inputLiftState);
            // Assert
            Assert.That(expectedMsg, Is.EqualTo(actualMsg));
        }
        [Test]
        public void FitPeopleOnTheLiftAndGetResultWithEmptySpaces()
        {
            // Arrange
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 2, 4, 3 };
            int waitingPeopleCount = 1;
            string expectedMsg = "The lift has 2 empty spots!\r\n3 4 3";
            // Act
            string actualMsg = liftSimulator.FitPeopleOnTheLiftAndGetResult(waitingPeopleCount, inputLiftState);
            // Assert
            Assert.That(expectedMsg, Is.EqualTo(actualMsg));
        }
        [Test]
        public void FitPeopleOnTheLiftAndGetResultWithFullSpaces()
        {
            // Arrange
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 2, 4, 3 };
            int waitingPeopleCount = 3;
            string expectedMsg = "All people placed and the lift if full.\r\n4 4 4";
            // Act
            string actualMsg = liftSimulator.FitPeopleOnTheLiftAndGetResult(waitingPeopleCount, inputLiftState);
            // Assert
            Assert.That(expectedMsg, Is.EqualTo(actualMsg));
        }

    }
}