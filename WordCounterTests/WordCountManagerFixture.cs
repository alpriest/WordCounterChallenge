using System.IO;
using System.Text;
using NUnit.Framework;
using WordCounterChallenge;

namespace WordCounterTests
{
	[TestFixture]
	public class WordCountManagerFixture
	{
		[Test]
		public void ManagerCountsWordsInStream()
		{
			// Arrange
			var stream = new MemoryStream(Encoding.UTF8.GetBytes("one. two two, three three three! four four, four. four"));

			// Act
			var counter = new WordCounter();
			var manager = new WordCountManager(counter, new BufferManager(), new ChunkedStreamReader(stream));
			manager.Execute();

			// Assert
			Assert.That(counter.Counts["one"], Is.EqualTo(1));
			Assert.That(counter.Counts["two"], Is.EqualTo(2));
			Assert.That(counter.Counts["three"], Is.EqualTo(3));
			Assert.That(counter.Counts["four"], Is.EqualTo(4));
		}
	}
}