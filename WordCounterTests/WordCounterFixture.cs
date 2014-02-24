using System.Linq;
using NUnit.Framework;
using WordCounterChallenge;

namespace WordCounterTests
{
	[TestFixture]
	public class WordCounterFixture
	{
		[Test]
		public void ReturnsOneWhenOnlyOneWord()
		{
			// Arrange
			var wc = new WordCounter();

			// Act
			wc.CountWords("single");

			// Assert
			Assert.That(wc.Counts.Single(w => w.Key == "single").Value, Is.EqualTo(1));
		}
		
		[Test]
		public void ReturnsBothWordsWhenTwoDistinctWords()
		{
			// Arrange
			var wc = new WordCounter();

			// Act
			wc.CountWords("two words");

			// Assert
			Assert.That(wc.Counts.Count, Is.EqualTo(2));
			Assert.That(wc.Counts.Single(w => w.Key == "two").Value, Is.EqualTo(1));
			Assert.That(wc.Counts.Single(w => w.Key == "words").Value, Is.EqualTo(1));
		}

		[Test]
		public void ReturnsCorrectCountsWhenDuplicatesWords()
		{
			// Arrange
			var wc = new WordCounter();

			// Act
			wc.CountWords("one two one one");

			// Assert
			Assert.That(wc.Counts.Count, Is.EqualTo(2));
			Assert.That(wc.Counts.Single(w => w.Key == "one").Value, Is.EqualTo(3));
			Assert.That(wc.Counts.Single(w => w.Key == "two").Value, Is.EqualTo(1));
		}
		
		[Test]
		public void AggregatesMultipleCalls()
		{
			// Arrange
			var wc = new WordCounter();

			// Act
			wc.CountWords("one two one one");
			wc.CountWords("one two one one");

			// Assert
			Assert.That(wc.Counts.Count, Is.EqualTo(2));
			Assert.That(wc.Counts.Single(w => w.Key == "one").Value, Is.EqualTo(6));
			Assert.That(wc.Counts.Single(w => w.Key == "two").Value, Is.EqualTo(2));
		}

		[Test]
		public void DoesNotConsiderAHyphenToBeAWordBreakingCharacter()
		{
			// Arrange
			var wc = new WordCounter();

			// Act
			wc.CountWords("one-two one one");

			// Assert
			Assert.That(wc.Counts.Count, Is.EqualTo(2));
			Assert.That(wc.Counts.Single(w => w.Key == "one-two").Value, Is.EqualTo(1));
			Assert.That(wc.Counts.Single(w => w.Key == "one").Value, Is.EqualTo(2));
		}

		[Test]
		public void ReturnsZeroWhenNoWordBoundary()
		{
			// Arrange
			var wc = new WordCounter();

			// Act
			var result = wc.LastPositionOfWordBoundary("one");

			// Assert
			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		public void ReturnsFinalIndexOfWordBoundaryWhenOneExists()
		{
			// Arrange
			var wc = new WordCounter();

			// Act
			var result = wc.LastPositionOfWordBoundary("one two three");

			// Assert
			Assert.That(result, Is.EqualTo(8));
		}
	}
}
