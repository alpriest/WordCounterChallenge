using Moq;
using NUnit.Framework;
using WordCounterChallenge;

namespace WordCounterTests
{
	[TestFixture]
	public class BufferManagerFixture
	{
		[Test]
		public void SplitsInputOnLastWordBoundaryPosition()
		{
			// Arrange
			var bufferManager = new BufferManager();
			var input = "before the last space";
			var wordCounter = new Mock<IWordCounter>();
			wordCounter.Setup(x => x.LastPositionOfWordBoundary(It.IsAny<string>())).Returns(15);

			// Act
			bufferManager.SplitInputChunk(wordCounter.Object, input);

			// Assert
			Assert.That(bufferManager.Current, Is.EqualTo("before the last"));
			Assert.That(bufferManager.Previous, Is.EqualTo(" space"));
		}

		[Test]
		public void DoesNotSplitWhenNoBoundary()
		{
			// Arrange
			var bufferManager = new BufferManager();
			var input = "before";
			var wordCounter = new Mock<IWordCounter>();
			wordCounter.Setup(x => x.LastPositionOfWordBoundary(It.IsAny<string>())).Returns(0);

			// Act
			bufferManager.SplitInputChunk(wordCounter.Object, input);

			// Assert
			Assert.That(bufferManager.Current, Is.EqualTo(string.Empty));
			Assert.That(bufferManager.Previous, Is.EqualTo("before"));
		}
	}
}
